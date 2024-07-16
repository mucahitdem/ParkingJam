using UnityEngine;

namespace Scripts.GameScripts.Helpers
{
    public static class CreatedZigZagPositions
    {
        private static Vector3 s_startPoint;
        private static Vector3 s_endPoint;

        private static Vector3 s_dist;
        private static Vector3 s_dir;
        private static Vector3 s_rightDir;
        private static float s_unitDist;

        private static Vector3[] s_pos;

        public static Vector3[] Positions(Vector3 startPoint, Vector3 endPoint, float maxSideValue, int count)
        {
            s_startPoint = startPoint;
            s_endPoint = endPoint;

            s_pos = new Vector3[count + 1];
            s_pos[^1] = endPoint;

            s_dist = Distance();
            s_dir = Distance().normalized;
            s_rightDir = Quaternion.Euler(0, 90, 0) * s_dir;

            var countToDivide = count + 1;
            s_unitDist = s_dist.magnitude / countToDivide;

            for (var i = 0; i < count; i++)
            {
                var sideAmount = i % 2 == 0 ? maxSideValue : -maxSideValue;
                s_pos[i] = startPoint + CalculateForwardPos(i) +
                           s_rightDir * sideAmount; /*CalculateRandomSidePos(maxSideValue);*/
            }

            return s_pos;
        }


        private static Vector3 CalculateForwardPos(int i)
        {
            return s_dir * s_unitDist * (i + 1);
        }

        private static Vector3 CalculateRandomSidePos(float maxSideValue)
        {
            return s_rightDir * Random.Range(-maxSideValue, maxSideValue);
        }

        private static Vector3 Distance()
        {
            return s_endPoint - s_startPoint;
        }
    }
}