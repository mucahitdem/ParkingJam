using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Helpers
{
    [RequireComponent(typeof(LineRenderer))]
    public class CreateCircle : BaseComponent
    {
        [SerializeField]
        private float heightOffset;

        [SerializeField]
        private LineRenderer lineRenderer;

        [SerializeField]
        private int numSegments = 32;

        [SerializeField]
        public float radius = 1f;


        [Button]
        public void DrawCircle(Transform target)
        {
            lineRenderer.positionCount = numSegments + 1;
            lineRenderer.loop = true;

            for (var i = 0; i <= numSegments; i++)
            {
                var angle = 2f * Mathf.PI * i / numSegments;
                var x = Mathf.Sin(angle) * radius;
                var z = Mathf.Cos(angle) * radius;
                var position = new Vector3(x, heightOffset, z) + target.position;
                lineRenderer.SetPosition(i, position);
            }
        }
        
        
        public void DrawCircle(float newRadius)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = numSegments + 1;
            lineRenderer.loop = true;

            for (var i = 0; i <= numSegments; i++)
            {
                var angle = 2f * Mathf.PI * i / numSegments;
                var x = Mathf.Sin(angle) * newRadius;
                var z = Mathf.Cos(angle) * newRadius;
                var position = new Vector3(x, heightOffset, z) + transform.position;
                lineRenderer.SetPosition(i, position);
            }
        }

        public void DisableCircle()
        {
            lineRenderer.enabled = false;
        }
    }
}