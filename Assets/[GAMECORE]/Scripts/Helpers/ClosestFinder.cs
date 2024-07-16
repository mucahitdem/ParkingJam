using System.Collections.Generic;
using System.Linq;
using Scripts.AllInterfaces;
using UnityEngine;

namespace Scripts.Helpers
{
    public class ClosestFinder : MonoBehaviour
    {
        public static T FindClosestType<T>(List<T> targets, Vector3 targetPoint) where T : IMonoBehaviour
        {
            var closestTransform = targets
                .OrderBy(obj => Vector3.Distance(obj.TransformOfObj.position, targetPoint))
                .First();
        
            return closestTransform;
        }
        
        public static T FindClosestTransform<T>(List<T> targets, Vector3 targetPoint) where T : IMonoBehaviour
        {
            var closestTransform = targets
                .OrderBy(obj => Vector3.Distance(obj.TransformOfObj.position, targetPoint))
                .First();

            return closestTransform;
        }

        public static void SortByDist<T>(ref List<T> targets, Vector3 targetPoint) where T : Transform
        {
            targets = targets
                .OrderBy(obj => Vector3.Distance(obj.position, targetPoint))
                .ToList();
        }

        public static void TargetsInRangeSortedByDist<T>(ref List<T> sortedList, Vector3 point, float maxRange)
            where T : IMonoBehaviour
        {
            float sqrMaxRange = maxRange * maxRange;

            for (int i = sortedList.Count - 1; i >= 0; i--)
            {
                T target = sortedList[i];
                float sqrDistance = (target.TransformOfObj.position - point).sqrMagnitude;

                if (sqrDistance > sqrMaxRange)
                {
                    sortedList.RemoveAt(i);
                }
            }

            sortedList.Sort((a, b) => (a.TransformOfObj.position - point).sqrMagnitude.CompareTo((b.TransformOfObj.position - point).sqrMagnitude));
        }
    }
}