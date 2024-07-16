using System;
using Scripts.BaseGameScripts.SourceManagement.SourceTypes.ClampedSourceManagement;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.SourceManagement
{
    public class ClampedSourceUi : BaseUiItem
    {
        [SerializeField]
        private ClampedSourceDataSo clampedSourceDataSo;

        [SerializeField]
        private TextMeshProUGUI sourceAmount;

        [SerializeField]
        private Image sourceIcon;

        [SerializeField]
        private Image fillBar;

        private float _maxAmount;

        private void Awake()
        {
            if(sourceIcon)
                sourceIcon.sprite = clampedSourceDataSo.baseSourceData.sourceIcon;
            _maxAmount = clampedSourceDataSo.clampedSourceData.maxSourceAmount;
            sourceAmount.text = 0 + "/" + _maxAmount;
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SourceActionManager.onClampedSourceUpdated += OnClampedSourceUpdated;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SourceActionManager.onClampedSourceUpdated -= OnClampedSourceUpdated;
        }
        
        
        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
        
        
        private void OnClampedSourceUpdated(ClampedSourceDataSo sourceDataSo, int currentSource)
        {
            var ratio = currentSource / _maxAmount;
            sourceAmount.text = currentSource + "/" + _maxAmount;
            if(fillBar)
                fillBar.fillAmount = ratio;
        }
    }
}