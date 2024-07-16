using System.Collections;
using System.Threading;
using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public class FrameRateManager : MonoBehaviour // not suggested to use
    {
        private float _currentFrameTime;

        [Header("Frame Settings")]
        public int maxRate = 9999;

        public float targetFrameRate = 60.0f;

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = maxRate;
            _currentFrameTime = Time.realtimeSinceStartup;
            StartCoroutine(WaitForNextFrame());
        }

        private IEnumerator WaitForNextFrame()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                _currentFrameTime += 1.0f / targetFrameRate;
                var t = Time.realtimeSinceStartup;
                var sleepTime = _currentFrameTime - t - 0.01f;
                if (sleepTime > 0)
                    Thread.Sleep((int) (sleepTime * 1000));
                while (t < _currentFrameTime)
                    t = Time.realtimeSinceStartup;
            }
        }
    }
}