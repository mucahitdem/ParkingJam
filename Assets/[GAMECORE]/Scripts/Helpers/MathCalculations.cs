using UnityEngine;

namespace Scripts.Helpers
{
    public static class MathCalculations
    {
        public static float CalculatePercentage(float mainVal, float percentage)
        {
            return mainVal * (percentage / 100f);
        }
        
        public static float CalculatePercentageAndAdd(float mainVal, float percentage)
        {
            return mainVal + mainVal * (percentage / 100f);
        }

        public static Vector3 CalculatePercentage(Vector3 mainVal, float percentage)
        {
            var percentageInFloat = percentage / 100f;
            return mainVal * percentageInFloat;
        }
    }
}