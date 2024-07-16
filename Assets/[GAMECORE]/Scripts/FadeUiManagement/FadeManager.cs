using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.FadeUiManagement
{
    public class FadeManager : SingletonMono<FadeManager>
    {
        [SerializeField]
        private float fadeDuration;

        [SerializeField]
        private Image fadeImage;
        
        protected override void OnAwake()
        {
        }

        
        
        
        public void Fade(Action doOnFaded)
        {
            fadeImage.raycastTarget = true;
            FadeIn(() =>
            {
                doOnFaded?.Invoke();
                FadeOut(()=> fadeImage.raycastTarget = false);
            });
        }
        public void FadeIn(Action onEnded = null)
        {
            FadeController(1, onEnded);
        }
        public void FadeOut(Action onEnded = null)
        {
            FadeController(0, onEnded);
        }
        
        
        
        
        private void FadeController(float fadeValue, Action onEnded)
        {
            fadeImage.raycastTarget = true;
            fadeImage.DOFade(fadeValue, fadeDuration).OnComplete(() =>
            {
                fadeImage.raycastTarget = false;
                onEnded?.Invoke();
            });
        }
    }
}