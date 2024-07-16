using System;
using System.Collections.Generic;
using DG.Tweening;
using GAME.Scripts.UiAnimationModule.UiAnims;
using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using Sirenix.Utilities;

namespace GAME.Scripts.UiAnimationModule
{
    public class UiAnimManager : EventSubscriber
    {
        private BaseUiAnim[] anims;
        private BaseUiItem uiItem;

        private readonly Dictionary<AnimPlayMoment, BaseUiAnim[]> momentsAndAnims = new Dictionary<AnimPlayMoment, BaseUiAnim[]>();
        
        private void Awake()
        {
            uiItem = GetComponent<BaseUiItem>();
            anims = GetComponents<BaseUiAnim>();
            anims.ForEach(a => a.Init(uiItem));
            for (int i = 0; i < anims.Length; i++)
            {
                var currentAnim = anims[i];
                if (momentsAndAnims.TryGetValue(currentAnim.AnimPlayMoment, out BaseUiAnim[] momentAnims))
                {
                    BaseUiAnim[] newArr = new BaseUiAnim[momentAnims.Length + 1];
                    for (int j = 0; j < momentAnims.Length; j++)
                    {
                        newArr[j] = momentAnims[j];
                    }

                    newArr[^1] = currentAnim;
                    momentsAndAnims[currentAnim.AnimPlayMoment] = newArr;
                }
                else
                {
                    momentsAndAnims.Add(currentAnim.AnimPlayMoment, new []{currentAnim});
                }
            }
        }
        
        
        public override void SubscribeEvent()
        {
            uiItem.onEnter += OnEnter;
            uiItem.onExit += OnExit;
            uiItem.onOpen += OnOpen;
            uiItem.onClose += OnClose;
            uiItem.onClick += OnClick;
        }
        public override void UnsubscribeEvent()
        {
            uiItem.onEnter -= OnEnter;
            uiItem.onExit -= OnExit;
            uiItem.onOpen -= OnOpen;
            uiItem.onClose -= OnClose;
            uiItem.onClick -= OnClick;
        }
        
        
        
        private void OnClick()
        {
            TryPlayAnim(AnimPlayMoment.Click, null);
        }
        private void OnClose()
        {
            TryPlayAnim(AnimPlayMoment.Close, ()=> uiItem.gameObject.SetActive(false));
        }
        private void OnOpen()
        {
            TryPlayAnim(AnimPlayMoment.Open, null);
        }
        private void OnExit()
        {
            TryPlayAnim(AnimPlayMoment.Exit, null);
        }
        private void OnEnter()
        {
            TryPlayAnim(AnimPlayMoment.Enter, null);
        }

        private void TryPlayAnim(AnimPlayMoment animPlayMoment, Action onComplete)
        {
            if (momentsAndAnims.TryGetValue(animPlayMoment, out BaseUiAnim[] animsToPlay))
            {
                animsToPlay.ForEach(a => a.PlayAnimSeq(uiItem, onComplete));
            }
            else
            {
                DebugHelper.LogYellow("NO ANIMS EXIST AT MOMENT : " + animPlayMoment.ToString());
            }
        }
    }
}