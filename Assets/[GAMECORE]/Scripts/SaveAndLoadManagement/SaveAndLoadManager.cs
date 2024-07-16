using Scripts.BaseGameScripts.Helper;

namespace Scripts.BaseGameScripts.SaveAndLoadManagement
{
    public class SaveAndLoadManager : SingletonMono<SaveAndLoadManager>
    {
        private ISaveAndLoad _tempSaveAndLoad;

        //[SerializeField]
        private ISaveAndLoad[] saveAndLoads;

        public void Save()
        {
            // for (int i = 0; i < saveAndLoads.Length; i++)
            // {
            //     var currentData = saveAndLoads[i];
            //     if (currentData.TryGetComponent(out _tempSaveAndLoad))
            //     {
            //         _tempSaveAndLoad.Save();
            //     }
            //     else
            //     {
            //         DebugHelper.LogYellow(currentData.charName + " --- " + "NOT SAVE AND LOAD");
            //     }
            // }
        }

        public void Load()
        {
            // for (var i = 0; i < saveAndLoads.Length; i++)
            // {
            //     var currentData = saveAndLoads[i];
            //     if (currentData.TryGetComponent(out _tempSaveAndLoad))
            //         _tempSaveAndLoad.Save();
            //     else
            //         DebugHelper.LogYellow(currentData.charName + " --- " + "NOT SAVE AND LOAD");
            // }
        }

        protected override void OnAwake()
        {
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
                Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                Save();
        }
    }
}