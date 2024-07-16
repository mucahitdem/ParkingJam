using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    [Serializable]
    public class SceneSerialization
    {
        [SerializeField]
        private bool isActiveScene;
        

        [SerializeField]
        private Object scene;

        public string sceneName;
        public bool IsActiveScene => isActiveScene;
        public Object Scene => scene;

        [Button]
        private void GetName()
        {
            sceneName = scene.name;
        }
    }
}