using System.Collections.Generic;
using Scripts.BaseGameScripts.ControlManagement;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlRotateWithSwipe : BaseControl
    {
        private bool _isTouchOnUi;
        protected CalculateDeltaMouse calculateDeltaMouse;

        protected float clampedXRot;
        protected float clampedYRot;

        [Header("Swipe Variables")]
        [SerializeField]
        protected float clampMaxVal;

        [SerializeField]
        protected float lerpMultiplier = 1;

        [SerializeField]
        protected float mouseDamp = 600;

        [SerializeField]
        protected Transform objToRotate;

        protected float screenHeight;


        protected float screenWidth;

        [SerializeField]
        protected MinMaxValue xRot;

        [SerializeField]
        protected MinMaxValue yRot;


        private void Awake()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            calculateDeltaMouse = new CalculateDeltaMouse();
        }


        protected override void Start()
        {
            base.Start();
            clampedXRot = 360 - xRot.maxVal;
            clampedYRot = 360 - yRot.maxVal;
        }

        [Button]
        public void UpdateClamps(MinMaxValue minMaxYRot)
        {
            yRot = minMaxYRot;
            clampedYRot = 360 - yRot.maxVal;
        }


        protected override void OnTapDown()
        {
            base.OnTapDown();
            TouchOnUI();

            calculateDeltaMouse.ResetValues();
        }

        protected override void OnTapHold()
        {
            if (_isTouchOnUi)
                return;
            base.OnTapHold();
            GetInput();
        }

        public override void GetInput()
        {
            calculateDeltaMouse.CalculateDeltaMousePos();
            Swipe();
        }

        protected virtual void Swipe()
        {
            if (!isControlEnabled)
                return;

            var objRot = objToRotate.eulerAngles;

            var objRotY = objRot.y;
            var objRotX = objRot.x;

            objRotY = Mathf.Lerp(objRotY, objRotY + mouseDamp * (calculateDeltaMouse.deltaMousePos.x / screenWidth),
                Time.deltaTime * lerpMultiplier);
            objRotX = Mathf.Lerp(objRotX, objRotX - mouseDamp * (calculateDeltaMouse.deltaMousePos.y / screenHeight),
                Time.deltaTime * lerpMultiplier);

            Clamp(ref objRotY, ref objRotX);

            objToRotate.eulerAngles = new Vector3(objRotX, objRotY, objRot.z);

            calculateDeltaMouse.ResetValues();
        }

        private float Clamp(ref float objRotY, ref float objRotX)
        {
            if (objRotY > 180 && objRotY < clampedYRot)
                objRotY = clampedYRot;
            else if (objRotY < 180 && objRotY >= yRot.maxVal) objRotY = yRot.maxVal;


            if (objRotX > 180 && objRotX < clampedXRot)
                objRotX = clampedXRot;
            else if (objRotX < 180 && objRotX >= xRot.maxVal) objRotX = clampMaxVal;

            return objRotY;
        }
    }
}