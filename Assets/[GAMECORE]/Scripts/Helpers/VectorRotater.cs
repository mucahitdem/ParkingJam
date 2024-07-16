using UnityEngine;

namespace Scripts.GameScripts.Helpers
{
    public static class VectorRotater
    {
        public static Vector3[] GenerateSpread(Vector3 dir, float maxAngle, int directionCount)
        {
            // Ensure the direction count is valid
            directionCount = Mathf.Max(1, directionCount);

            // Calculate the angle step between directions
            var angleStep = maxAngle / (directionCount - 1);

            // Calculate the initial angle from the center direction
            var initialAngle = -maxAngle / 2f;

            // Create the array to store the spread of directions
            var directions = new Vector3[directionCount];

            // Normalize the direction vector to ensure it has magnitude 1
            dir.Normalize();

            // Calculate the spread of directions
            for (var i = 0; i < directionCount; i++)
            {
                // Calculate the angle for this direction
                var angle = initialAngle + angleStep * i;

                // Convert the angle from degrees to radians
                var angleRadians = angle * Mathf.Deg2Rad;

                // Calculate the direction vector using basic trigonometry
                var spreadDirection = new Vector3(Mathf.Sin(angleRadians), 0f, Mathf.Cos(angleRadians));

                // Apply the rotation based on the initial direction
                spreadDirection = Quaternion.LookRotation(dir) * spreadDirection;

                // Store the direction in the array
                directions[i] = spreadDirection;
            }

            return directions;
        }
    }
}