using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SceneLoadingManagement;
using UnityEngine;

namespace Scripts
{
    public class BaseGameManager : SingletonMono<BaseGameManager>
    {
        [SerializeField]
        private Camera loaderCamera;

        public Camera LoaderCamera => loaderCamera;

        protected override void OnAwake()
        {
        }

        
        

        private void OnEnable()
        {
            SceneLoadActionManager.onLoadingSceneStarted += OnLoadingSceneStarted;
            SceneLoadActionManager.onLoadingSceneCompleted += OnLoadingSceneCompleted;
        }
        private void OnDisable()
        {
            SceneLoadActionManager.onLoadingSceneStarted -= OnLoadingSceneStarted;
            SceneLoadActionManager.onLoadingSceneCompleted -= OnLoadingSceneCompleted;
        }


        
        
        private void OnLoadingSceneStarted()
        {
        }
        private void OnLoadingSceneCompleted(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelDataSo)
        {
        }
    }
}