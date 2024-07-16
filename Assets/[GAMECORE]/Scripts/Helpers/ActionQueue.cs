using System;
using System.Collections.Generic;
using Scripts.ServiceLocatorModule;
using Scripts.UpdateManagement;
using UnityEngine;

namespace Scripts.Helpers
{
    public class ActionQueue : MonoBehaviour,IUpdate
    {
        private Queue<Action> actions = new Queue<Action>();
        private bool isInProcess;
        private UpdateManager updateManager;

        private void Start()
        {
            updateManager = ServiceLocator.Instance.GetService<UpdateManager>();
            updateManager.Register(this);
        }


        public void OnUpdate()
        {
            if (actions.Count > 0 && !isInProcess)
            {
                isInProcess = true;
                actions.Dequeue()?.Invoke();
            }
        }
        public void AddAction(Action action)
        {
            actions.Enqueue(()=>
            {
                action?.Invoke();
                isInProcess = false;
            });
        }
    }
}