using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.ControlManagement
{
    public class CalculateDeltaMouse
    {
        private Vector2 _currentMousePos;

        [ReadOnly]
        public Vector2 deltaMousePos;

        [ReadOnly]
        private Vector2 mouseStartPos;

        public void CalculateDeltaMousePos(int touchIndex = 0)
        {
#if UNITY_EDITOR
            _currentMousePos = Input.mousePosition;
#elif UNITY_ANDROID 
            _currentMousePos = CurrentTouchPosOnTouchScreen(touchIndex);
#elif UNITY_IOS 
            _currentMousePos = CurrentTouchPosOnTouchScreen(touchIndex);
#endif
            
            deltaMousePos = new Vector2(_currentMousePos.x - mouseStartPos.x,_currentMousePos.y - mouseStartPos.y);
        }

        public void ResetValues(int touchIndex = 0)
        {
#if UNITY_EDITOR
            mouseStartPos = Input.mousePosition;
#elif UNITY_ANDROID 
            mouseStartPos = ResetOnTouchScreen(touchIndex);
#elif UNITY_IOS	
            mouseStartPos = ResetOnTouchScreen(touchIndex);
#endif
        }

        private Vector3 ResetOnTouchScreen(int touchIndex)
        {
            return Input.GetTouch(touchIndex).position;
        }
        
        private Vector3 CurrentTouchPosOnTouchScreen(int touchIndex)
        {
            return Input.GetTouch(touchIndex).position;
        }
    }
}