using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Scripts.BaseGameScripts.DevHelperTools.Editor
{
    public class DeveloperWindow : OdinMenuEditorWindow
    {
        [MenuItem("Developer Tools/Developer Window")]
        private static void OpenWindow()
        {
            GetWindow<DeveloperWindow>().Show();
        }


        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.Selection.SupportsMultiSelect = false;

            tree.Add("Game Settings", GameSettingsDataSo.Instance);


            return tree;
        }
    }
}