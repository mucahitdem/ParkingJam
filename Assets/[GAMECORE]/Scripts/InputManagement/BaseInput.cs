using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.InputManagement
{
    public abstract class BaseInput : BaseComponent
    {
        private bool _isTouchScreen;
        private PointerEventData eventDataCurrentPosition;

        protected virtual void Start()
        {
            TouchSettings();
        }
        protected virtual void Update()
        {
            GetInput();
        }

        private void TouchSettings()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _isTouchScreen = true;
                Input.multiTouchEnabled = true;
            }
            else
            {
                _isTouchScreen = false;
            }
        }

        private void GetInput()
        {
            if (_isTouchScreen)
                TouchControl();
            else
                MouseControl();
        }
        private void MouseControl()
        {
            if (Input.GetMouseButtonDown(0))
                OnTapDown();
            else if (Input.GetMouseButton(0))
                OnTapHold();
            else if (Input.GetMouseButtonUp(0)) OnTapUp();
        }
        private void TouchControl()
        {
            if (Input.touchCount <= 0)
                return;
            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    OnTapDown();
                    break;

                case TouchPhase.Moved:
                    OnTapHold();
                    break;

                case TouchPhase.Stationary:
                    OnTapHoldAndNotMove();
                    break;

                case TouchPhase.Ended:
                    OnTapUp();
                    break;
            }
        }
        
        
        protected virtual void OnTapDown()
        {
            // if (TouchOnUI())
            //     return;

            InputActionManager.onTapDown?.Invoke();
        }
        protected virtual void OnTapHold()
        {
            InputActionManager.onTapAndHold?.Invoke();
        }
        protected virtual void OnTapHoldAndNotMove()
        {
            InputActionManager.onTapAndHoldAndNotMove?.Invoke();
        }
        protected virtual void OnTapUp()
        {
            InputActionManager.onTapUp?.Invoke();
        }



        protected bool TouchOnUI(int touchIndex = 0)
        {
            if (!EventSystem.current)
                return false;

            if (eventDataCurrentPosition == null)
                eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            

#if UNITY_EDITOR
            eventDataCurrentPosition.position = Input.mousePosition;
#elif UNITY_ANDROID || UNITY_IOS
            eventDataCurrentPosition.position = Input.GetTouch(touchIndex).position;
#endif

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count != 0;
        }
    }
}