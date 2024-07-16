using Scripts.BaseGameScripts.Pool;
using Scripts.TimerManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.TimerManagement
{
    public class PooledTimer : Timer
    {
        [field: SerializeField]
        public BasePoolItem Pool { get; private set; }
        
        protected override void OnTimerEnded()
        {
            base.OnTimerEnded();
            Pool.AddObjToPool(gameObject);
        }
    }
}