using GAME.Scripts;
using Scripts.BaseGameScripts.Animator_Control;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.Helpers
{
    public class MoveTowardsTarget : BaseComponent
    {
        [SerializeField]
        private AnimatorStateManager animatorStateManager;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float stoppingDistance;

        [SerializeField]
        private Transform target;

        protected void Update()
        {
            LookAtTarget();
        }

        protected void FixedUpdate()
        {
            Move();
        }


        protected void AnimatorControl()
        {
            UpdateAnimatorWithInput();
        }

        private void UpdateAnimatorWithInput()
        {
            if (DistToTarget() > stoppingDistance)
            {
                if (!animatorStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    animatorStateManager.SetBool(Defs.ANIM_KEY_WALK, true);
            }
            else
            {
                if (animatorStateManager.GetBool(Defs.ANIM_KEY_WALK))
                    animatorStateManager.SetBool(Defs.ANIM_KEY_WALK, false);
            }
        }


        private float DistToTarget()
        {
            return Vector3.Distance(TransformOfObj.position, target.position);
        }

        private void Move()
        {
            Rb.velocity = TransformOfObj.forward * (speed * Time.deltaTime);
        }

        private void LookAtTarget()
        {
            var playerPos = target.position;
            var worldPosition = new Vector3(playerPos.x, 0, playerPos.z);
            TransformOfObj.LookAt(worldPosition, Vector3.up);
        }
    }
}