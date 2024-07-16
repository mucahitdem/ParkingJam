using GAME.Scripts;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.SceneLoadingManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    public class SceneLoadManager : BaseComponent
    {
        private Camera _loaderCamera;

        private int _sceneIndexToLoad;
        private ScenesToLoadAtLevelDataSo _scenes;

        [SerializeField]
        private BaseAsyncSceneLoader baseAsyncSceneLoader;
        private Camera LoaderCamera
        {
            get
            {
                if (!_loaderCamera)
                    _loaderCamera = BaseGameManager.Instance.LoaderCamera;
                return _loaderCamera;
            }
        }
        

        private void Start()
        {
            UpdateData();
            LoadScene(_scenes);
        }
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SceneLoadActionManager.loadScene += LoadScene;
            SceneLoadActionManager.reloadScene += ReloadScene;
            SceneLoadActionManager.onLoadingSceneCompleted += OnScenesLoaded;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SceneLoadActionManager.loadScene -= LoadScene;
            SceneLoadActionManager.reloadScene -= ReloadScene;
            SceneLoadActionManager.onLoadingSceneCompleted -= OnScenesLoaded;
        }
        
        
        
        

        private void ReloadScene()
        {
            baseAsyncSceneLoader.ReloadScene();
        }
        private void UpdateData()
        {
            _sceneIndexToLoad = PlayerPrefs.GetInt(Defs.SAVE_KEY_LEVEL, 0);
            _scenes = AllLevelsDataSo.Instance.ScenesToLoadAtLevels[_sceneIndexToLoad];
        }
        private void OnScenesLoaded(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelDataSo)
        {
            LoaderCamera.gameObject.SetActive(false);
        }
        private void LoadScene(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelsDataSo)
        {
            if (scenesToLoadAtLevelsDataSo == null)
                DebugHelper.LogRed("NULL SCENES DATA");
            baseAsyncSceneLoader.LoadScene(scenesToLoadAtLevelsDataSo);
        }
    }
}