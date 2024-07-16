using Scripts.BaseGameScripts.TimerManagement;
using Scripts.TimerManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement.SourceTypes.RenewableClampedSourceManagement
{
    public class RenewableClampedSource : BaseSource
    {
        private RenewableClampedSourceDataSo _dataSo;

        [SerializeField]
        private Timer timer;

        protected void Awake()
        {
            _dataSo = (RenewableClampedSourceDataSo) baseSourceDataSo;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if (timer)
                timer.onTimerEnded += OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            AddSource(1);
        }

        private void AddSource(int count)
        {
            currentSource += count;
            currentSource = Mathf.Clamp(currentSource, 0, _dataSo.data.maxSourceCount);
            Save();
        }
    }
}