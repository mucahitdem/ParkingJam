using System;
using GAME.Scripts.UiAnimationModule;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.ServiceLocatorModule;
using Scripts.SoundManagement;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Scripts.UiManagement.BaseUiItemManagement
{
    public abstract class BaseUiItem : BaseComponent
    {
        public Action onEnter;
        public Action onExit;
        public Action onClose;
        public Action onOpen;
        public Action onClick;

        
        [SerializeField]
        private bool setIdViaInspector;

        [ShowIf("setIdViaInspector")]
        [SerializeField]
        protected string uiItemId;

        [ShowInInspector]
        public string UiItemId
        {
            get
            {
                if (uiItemId.IsNullOrWhitespace())
                    try
                    {
                        uiItemId = GetUiId();
                    }
                    catch
                    {
                        uiItemId = "";
                    }

                return uiItemId;
            }
        }

        protected SoundManager soundManager;
        private UiAnimManager _uiAnimManager;

        protected virtual void Start()
        {
            soundManager = ServiceLocator.Instance.GetService<SoundManager>();
            _uiAnimManager = GetComponent<UiAnimManager>();
        }

        public virtual void ShowUi()
        {
            Go.SetActive(true);
            onOpen?.Invoke();
        }
        public virtual void HideUi()
        {
            if(_uiAnimManager)
                onClose?.Invoke();
            else
                Go.SetActive(false);
        }

        [Button]
        protected abstract string GetUiId();

        // public virtual void OnPointerEnter(PointerEventData eventData)
        // {
        //    onEnter?.Invoke();
        // }
        //
        // public void OnPointerExit(PointerEventData eventData)
        // {
        //     onExit?.Invoke();
        // }
    }
}