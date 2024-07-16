using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    public class SceneLoadButton : BaseUiButton
    {
        private void LoadScene()
        {
            var allScenes = AllLevelsDataSo.Instance.ScenesToLoadAtLevels;
            SceneLoadActionManager.loadScene?.Invoke(allScenes[1]);
        }

        protected override string GetUiId()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnClick()
        {
            base.OnClick();
            LoadScene();
        }
    }
}