using System;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;

namespace GAME.Scripts.UiAnimationModule.UiAnims
{
    public abstract class BaseUiAnim : MonoBehaviour
    {
        public AnimPlayMoment AnimPlayMoment => animPlayMoment;
        
        [SerializeField]
        private AnimPlayMoment animPlayMoment;

        [SerializeField]
        protected bool customize;


        public virtual void Init(BaseUiItem uiItem)
        {
            
        }
        public abstract void PlayAnimSeq(BaseUiItem target, Action onComplete);
    }
}