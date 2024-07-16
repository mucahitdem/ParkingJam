using UnityEngine;

namespace Scripts.Helpers
{
    public static class ProbabilityCalculator
    {
        private static float s_randomNumber;

        public static bool CheckProbability(float percentage)
        {
            percentage = Mathf.Clamp(percentage, 0f, 100f);

            s_randomNumber = Random.Range(1, 100);
            return s_randomNumber <= percentage;
        }
    }
}