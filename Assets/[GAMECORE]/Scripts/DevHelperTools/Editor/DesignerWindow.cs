using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Scripts.DevHelperTools.Editor
{
    public class DesignerWindow : OdinMenuEditorWindow
    {
        [MenuItem("Designer Tools/Settings")]
        private static void OpenWindow()
        {
            GetWindow<DesignerWindow>().Show();
        }


        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.Selection.SupportsMultiSelect = false;

            return tree;
        }
    }
}