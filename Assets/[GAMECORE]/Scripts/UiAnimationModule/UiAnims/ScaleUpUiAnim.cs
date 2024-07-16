using System;
using DG.Tweening;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GAME.Scripts.UiAnimationModule.UiAnims
{
    [Serializable]
    public class ScaleUpUiAnim : BaseUiAnim
    {
        [ShowIf(nameof(customize))]
        [SerializeField]
        private Vector3 targetScale;
        
        [ShowIf(nameof(customize))]
        [SerializeField]
        private float duration;

     
        
        
        public override void PlayAnimSeq(BaseUiItem target, Action onComplete)
        {
            target.RectTransformObj.localScale = Vector3.zero;
            target.RectTransformObj.DOScale(customize ? targetScale : Vector3.one, customize ? duration : .25f).SetEase(Ease.OutCirc)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                });
        }
    }
}