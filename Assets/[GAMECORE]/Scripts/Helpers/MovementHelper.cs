using UnityEngine;

namespace Scripts.Helpers
{
    public static class MovementHelper
    {
        private static Matrix4x4 s_isoMatrix  = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        public static Vector3 ToIso(this Vector3 input) => s_isoMatrix.MultiplyPoint3x4(input);
    }
}