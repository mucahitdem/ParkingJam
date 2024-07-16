using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts
{
    public class EventQueue : MonoBehaviour
    {
        private readonly Dictionary<string, Action> _actionAndId;
        private readonly Queue<ActionData> _eventQueue;
        private bool _isProcessing;
        private ActionData _lastInvokedAction;
        private Action _tempAct;

        public EventQueue()
        {
            _actionAndId = new Dictionary<string, Action>();
            _eventQueue = new Queue<ActionData>();
            _isProcessing = false;
        }


        private void OnQueueUpdated()
        {
            if (_eventQueue.Count > 0 && !_isProcessing)
            {
                _lastInvokedAction = _eventQueue.Dequeue();
                _lastInvokedAction.action?.Invoke();
                _isProcessing = true;
            }
        }

        public void Add(Action actionToEnqueue, string actionId)
        {
            if (ActionExistWithSameId(actionId))
            {
                Debug.LogWarning("ALREADY EXIST AN ACTION WITH THIS ID");
                return;
            }

            _actionAndId.Add(actionId, actionToEnqueue);
            var newActionData = new ActionData
            {
                action = actionToEnqueue,
                actionId = actionId
            };
            _eventQueue.Enqueue(newActionData);
            OnQueueUpdated();
        }

        public void Kill(string actionId)
        {
            if (actionId == _lastInvokedAction.actionId)
            {
                _isProcessing = false;
                OnQueueUpdated();
            }
            else
            {
                Debug.LogError("THIS IS NOT THE RIGHT ACTION TO END");
                Debug.Assert(true, "THIS IS A BREAK");
            }
        }


        private bool ActionExistWithSameId(string actionId)
        {
            if (_actionAndId.TryGetValue(actionId, out _tempAct))
                return true;

            return false;
        }
    }

    public class ActionData
    {
        public Action action;
        public string actionId;
    }
}