using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SceneLoadingManagement;

namespace Scripts.Managers
{
    public class LevelManager : SingletonMono<LevelManager>
    {
        private int _lastLoadedLevelNum;
        protected override void OnAwake()
        {
            _lastLoadedLevelNum = 1;
        }


        public void LoadLevel(int levelNum)
        {
            _lastLoadedLevelNum = levelNum;
            SceneLoadActionManager.loadScene?.Invoke(AllLevelsDataSo.Instance.LevelWithName("Level" + levelNum));
        }
        public void NextLevel()
        {

        }
        public void RetryLevel()
        {
            SceneLoadActionManager.reloadScene?.Invoke();
        }
    }
}