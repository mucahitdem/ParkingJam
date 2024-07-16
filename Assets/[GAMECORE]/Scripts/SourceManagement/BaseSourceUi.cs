using System;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.SourceManagement
{
    public class BaseSourceUi : BaseUiItem
    {
        [SerializeField]
        private BaseSourceDataSo baseSourceDataSo;

        [SerializeField]
        private TextMeshProUGUI currentSource;

        [SerializeField]
        private Image sourceIcon;

        public override void OnEnable()
        {
            base.OnEnable();
            UpdateSourceVisual();
        }

        [Button]
        private void UpdateSourceVisual()
        {
            if (sourceIcon)
                sourceIcon.sprite = baseSourceDataSo.baseSourceData.sourceIcon;
            
            currentSource.text = SourceActionManager.getCurrentSource.Invoke(baseSourceDataSo).ToString();
        }


        protected override string GetUiId()
        {
            return null;
        }
        
        
        

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SourceActionManager.onSourceUpdated += OnSourceUpdated;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SourceActionManager.onSourceUpdated -= OnSourceUpdated;
        }
        private void OnSourceUpdated(BaseSourceDataSo source, int sourceAmount)
        {
            if(source == baseSourceDataSo)
                currentSource.text = sourceAmount.ToString();
        }
    }
}