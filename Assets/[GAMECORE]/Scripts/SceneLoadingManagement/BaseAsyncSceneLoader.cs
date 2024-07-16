using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.FadeUiManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SceneLoadingManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.SceneLoadingManagement
{
    public class BaseAsyncSceneLoader : BaseComponent
    {
        private string[] _lastLoadedSceneNames;

        public void LoadScene(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelsDataSo)
        {
            FadeManager.Instance.FadeIn(() =>
            {
                StartCoroutine(LoadScenes(scenesToLoadAtLevelsDataSo));
            });
        }
        public void ReloadScene()
        {
            FadeManager.Instance.FadeIn(() =>
            {
                var scenesToLoad = AllLevelsDataSo.Instance.LevelWithName(_lastLoadedSceneNames[0]);
                StartCoroutine(LoadScenes(scenesToLoad));
            });
        }

        
        private IEnumerator LoadScenes(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelsDataSo)
        {
            SceneLoadActionManager.onLoadingSceneStarted?.Invoke();

            UnloadScenes();
            
            if (!scenesToLoadAtLevelsDataSo)
                DebugHelper.LogRed("NULL SCENE DATA");
            var allScenesToLoad = scenesToLoadAtLevelsDataSo.allScenesToLoad;
            var sceneNames = scenesToLoadAtLevelsDataSo.GetScenesToLoad();
            var sceneLoadOperations = new List<AsyncOperation>();

            for (var i = 0; i < sceneNames.Length; i++)
            {
                if (_lastLoadedSceneNames != null)
                    for (var j = 0; j < _lastLoadedSceneNames.Length; j++)
                    {
                        var currentLastLoadedSceneName = _lastLoadedSceneNames[j];
                        // if (sceneNames[i] == currentLastLoadedSceneName)
                        //     break;
                    }

                var operation = SceneManager.LoadSceneAsync(sceneNames[i], LoadSceneMode.Additive);
                operation.allowSceneActivation = false;
                sceneLoadOperations.Add(operation);
            }
            while (!AllScenesLoaded(sceneLoadOperations))    
            {
                var totalProgress = CalculateOverallProgress(sceneLoadOperations, sceneNames);
                SceneLoadActionManager.sceneCompletePercentage?.Invoke(totalProgress);
                yield return null;
            }
            for (var i = 0; i < sceneLoadOperations.Count; i++)
            {
                var currentSceneName = sceneNames[i];
                var sceneToLoad = SceneManager.GetSceneByName(currentSceneName);
                sceneLoadOperations[i].allowSceneActivation = true;
                yield return new WaitUntil(() => sceneToLoad.isLoaded);
                if (allScenesToLoad[i].IsActiveScene)
                    SceneManager.SetActiveScene(sceneToLoad);
            }


            _lastLoadedSceneNames = sceneNames;


            SceneLoadActionManager.onLoadingSceneCompleted?.Invoke(scenesToLoadAtLevelsDataSo);
            FadeManager.Instance.FadeOut();
        }
        private void UnloadScenes()
        {
            if (_lastLoadedSceneNames != null)
            {
                for (var i = 0; i < _lastLoadedSceneNames.Length; i++)
                {
                    SceneManager.UnloadSceneAsync(_lastLoadedSceneNames[i]);
                }
            }
        }
        private bool AllScenesLoaded(List<AsyncOperation> operations)
        {
            foreach (var operation in operations)
                if (operation.progress < .9f)
                    return false;
            return true;
        }
        private float CalculateOverallProgress(List<AsyncOperation> operations, string[] sceneNames)
        {
            var totalProgress = 0f;
            foreach (var operation in operations) totalProgress += operation.progress;
            // Calculate the average progress of all scenes.
            return totalProgress / sceneNames.Length;
        }
    }
}