using GAME.Scripts;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.SceneLoadingManagement.Ui
{
    public class LoadingSceneUi : BaseUiItem
    {
        [SerializeField]
        private Image loadBar;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SceneLoadActionManager.sceneCompletePercentage += UpdateLoadBar;
            SceneLoadActionManager.onLoadingSceneCompleted += OnLoadingSceneCompleted;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SceneLoadActionManager.sceneCompletePercentage -= UpdateLoadBar;
            SceneLoadActionManager.onLoadingSceneCompleted -= OnLoadingSceneCompleted;
        }


        private void OnLoadingSceneCompleted(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelDataSo)
        {
            Go.SetActive(false);
        }

        private void UpdateLoadBar(float progress)
        {
            loadBar.fillAmount = progress;
        }

        protected override string GetUiId()
        {
            return Defs.UI_KEY_LOADING_SCREEN;
        }
    }
}