using System;
using Scripts.FindTargetsInAreaManagement;
using UnityEngine;

namespace Scripts.Helpers
{
    public class FieldDamagerManager : MonoBehaviour
    {
        [SerializeField]
        private FindTargetsInArea findTargetsInArea;

        [SerializeField]
        private ActionQueue actionQueue;

        private void Awake()
        {
            actionQueue = gameObject.AddComponent<ActionQueue>();
        }


        public void ScanAndDamage(Vector3 targetPos, float newDamageRadius, LayerMask targetLayer, Action<Collider> toDo)
        {
            actionQueue.AddAction(() =>
            {
                findTargetsInArea.SetData(newDamageRadius, targetLayer);
                findTargetsInArea.Scan(toDo, targetPos);
            });
        }
    }
}