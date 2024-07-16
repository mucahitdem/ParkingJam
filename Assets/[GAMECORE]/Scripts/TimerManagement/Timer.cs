using System;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.ServiceLocatorModule;
using UnityEngine;

namespace Scripts.TimerManagement
{
    public class Timer : MonoBehaviour
    {
        public Action onTimerEnded;

        [SerializeField]
        private TimerData timerData;
        
        public float PassedDurationRate => (timerData.timerValue - TimerValue) / timerData.timerValue; // returns between 0 - 1
        public float RemainedDurationRate => TimerValue / timerData.timerValue; // returns between 0 - 1

        public bool IsRunning { get; private set; }
        private bool IsPaused { get; set; }

        public float TimerValue
        {
            get => _timerValue;
            set
            {
                if (Math.Abs(value - _timerValue) > .0001f)
                {
                    _timerValue = value;

                    if (IsTimerEnded()) OnTimerEnded();
                }
            }
        }
        private float timerValueOnPaused;
        private float _timerValue;
        private TimerManager timerManager;

        private void Awake()
        {
            timerManager = ServiceLocator.Instance.GetService<TimerManager>();

            if (!timerData.restartManually) 
                RestartTimer();
        }
        private void Start()
        {
            if(IsRunning)
                timerManager.AddNewTimer(this);
        }
        
        public void RestartTimer()
        {
            if (IsPaused)
                IsPaused = false;

            ResetTimer();
            StartTimer();
        }
        public void PausePlayTimer(bool pause)
        {
            IsPaused = pause;
            if (IsPaused)
                StopTimer();
            else
                StartTimer();
        }
        public void StopTimer()
        {
            IsRunning = false;
            timerManager.RemoveTimer(this);
        }
        public void UpdateTimerValue(float newTimerValue)
        {
            timerData.timerValue = newTimerValue;
        }
        public void OnUpdate(float deltaTime)
        {
            TimerValue -= deltaTime;
        }

        
        
        private bool IsTimerEnded()
        {
            return _timerValue <= 0f;
        }
        protected virtual void OnTimerEnded()
        {
            onTimerEnded?.Invoke();

            if (timerData.isRepeating)
                ResetTimer();
            else
                StopTimer();
        }
        private void StartTimer()
        {
            IsRunning = true; 
            timerManager.AddNewTimer(this);
        }
        private void ResetTimer()
        {
            TimerValue = timerData.timerValue;
        }
    }
}