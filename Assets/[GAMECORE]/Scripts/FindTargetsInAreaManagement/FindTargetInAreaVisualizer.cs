using Scripts.BaseGameScripts.ComponentManagement;
using UnityEditor;
using UnityEngine;

namespace Scripts.FindTargetsInAreaManagement
{
    public class FindTargetInAreaVisualizer : BaseComponent
    {
        [SerializeField]
        private bool disableVisual;

        [SerializeField]
        private Color gizmosColor = Color.red;
        
        private float radius;
        private Transform castPosition;

        public void LoadNewData(float newRadius, Transform castPoint)
        {
            radius = newRadius;
            castPosition = castPoint;
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if(!castPosition)
                return;
            Handles.color = gizmosColor;
            Handles.DrawWireDisc(castPosition.position, Vector3.up, radius);

#endif
        }
    }
}