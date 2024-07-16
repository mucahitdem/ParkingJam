using GAME.Scripts;
using Scripts.SoundManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement
{
    public abstract class BaseUiButton : BaseUiItem
    {
        [SerializeField]
        private bool playSoundOnTap = true;

        [SerializeField]
        private bool useCustomSound;

        [ShowIf("useCustomSound")]
        [SerializeField]
        private string audioId;
        
        private Button _button;

        private Button Button
        {
            get
            {
                if (!_button)
                    _button = GetComponent<Button>();
                return _button;
            }
            set => _button = value;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if (Button)
                Button.onClick.AddListener(OnClick);
            else
                Debug.LogError("NO BUTTON FOUND !!!! ");
        }
        public override void UnsubscribeEvent()
        {
            base.SubscribeEvent();
            if (Button)
                Button.onClick.RemoveListener(OnClick);
        }

        
        protected virtual void OnClick()
        {
            PlaySound();
        }
        protected override string GetUiId()
        {
            return "";
        }
        protected virtual void PlaySound()
        {
            if(!playSoundOnTap)
                return;
            if(soundManager)
                soundManager.PlayAudio(useCustomSound ? audioId : SoundManager.AUDIO_BUTTON_CLICK);
        }
    }
}