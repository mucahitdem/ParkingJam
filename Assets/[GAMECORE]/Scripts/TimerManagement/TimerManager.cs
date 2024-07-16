using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.ServiceLocatorModule;
using Scripts.TimerManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.TimerManagement
{
    public class TimerManager : MonoBehaviour
    {
        private readonly List<Timer> _timerList = new List<Timer>();

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService(this);
        }

        private void Update()
        {
            UpdateTimers();
        }


        public void AddNewTimer(Timer timer)
        {
            if (!_timerList.Contains(timer))
                _timerList.Add(timer);
        }

        public void RemoveTimer(Timer timer)
        {
            if (_timerList.Contains(timer))
                _timerList.Remove(timer);
        }

        public void RemoveAllTimers()
        {
            _timerList.Clear();
        }

        private void UpdateTimers()
        {
            var currentDeltaTime = Time.deltaTime;
            for (var i = 0; i < _timerList.Count; i++) 
                _timerList[i].OnUpdate(currentDeltaTime);
        }
    }
}