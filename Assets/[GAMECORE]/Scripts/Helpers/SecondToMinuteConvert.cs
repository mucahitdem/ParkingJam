using UnityEngine;

namespace Scripts.GameScripts.Helpers
{
    public class SecondToMinuteConvert
    {
        public static string GetFormattedTime(float currentTime)
        {
            // Calculate minutes and seconds
            var minutes = Mathf.FloorToInt(currentTime / 60.0f);
            var seconds = Mathf.FloorToInt(currentTime % 60.0f);

            // Format the time as a string
            var timeString = $"{minutes:00}:{seconds:00}";
            return timeString;
        }
    }
}