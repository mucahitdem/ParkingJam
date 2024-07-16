using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public class TargetFrameManager : BaseComponent
    {
        [SerializeField]
        private int targetFrameRateAndroid;

        [SerializeField]
        private int targetFrameRateIos;

        private void Awake()
        {
#if UNITY_ANDROID || UNITY_EDITOR
            Application.targetFrameRate = targetFrameRateAndroid;
#elif UNITY_IOS
            Application.targetFrameRate = targetFrameRateIos;
#endif
        }
    }
}