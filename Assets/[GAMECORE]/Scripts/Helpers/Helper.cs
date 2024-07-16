using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Helpers
{
    public static class Helper
    {
        public static void SetLayer(this GameObject go, string layer)
        {
            go.layer = LayerMask.NameToLayer(layer);
        }

        public static bool InRange(this Transform tr, Vector3 targetPos, float range)
        {
            return Vector3.Distance(tr.position, targetPos) <= range;
        }
        
        public static T Random<T>(this List<T> list) where T : Object
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}