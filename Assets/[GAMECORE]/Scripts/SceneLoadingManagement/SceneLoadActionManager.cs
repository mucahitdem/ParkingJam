using System;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    public static class SceneLoadActionManager
    {
        public static Action onLoadingSceneStarted;
        public static Action<ScenesToLoadAtLevelDataSo> loadScene;
        public static Action reloadScene;
        public static Action<float> sceneCompletePercentage;
        public static Action<ScenesToLoadAtLevelDataSo> onLoadingSceneCompleted;
    }
}