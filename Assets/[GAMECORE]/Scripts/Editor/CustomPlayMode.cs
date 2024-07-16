using Scripts.BaseGameScripts;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Scripts.Editor
{
    [InitializeOnLoad] // Ensure the script runs when Unity starts up
    public class CustomPlayMode
    {
        static CustomPlayMode()
        {
            // Subscribe to the play mode state changed event
            EditorApplication.playModeStateChanged += LoadDefaultScene;
        }

        private static void LoadDefaultScene(PlayModeStateChange state)
        {
            // if(!GameSettingsDataSo.Instance || !GameSettingsDataSo.Instance.autoStartViaLoader)
            //     return;
            
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                if (SceneManager.GetActiveScene().isDirty)
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

                var path = "Assets/[GAMECORE]/Scenes/Loader.unity";
                EditorSceneManager.OpenScene(path);
            }
        }
    }
}