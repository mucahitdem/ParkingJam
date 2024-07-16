#if UNITY_EDITOR

using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Scripts.BaseGameScripts
{
    public class MakeAssetsAddressable : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] objs;

        [SerializeField]
        private AddressableAssetGroup group;
        
        [Button]
        private void SetAddressableName()
        {
            for (int i = 0; i < objs.Length; i++)
            {
                var currentObj = objs[i];
                string assetPath = AssetDatabase.GetAssetPath(currentObj);
                string assetGuid = AssetDatabase.AssetPathToGUID(assetPath);

                AddressableAssetSettingsDefaultObject.Settings.CreateOrMoveEntry(assetGuid, group);
                AddressableAssetSettingsDefaultObject.Settings.FindAssetEntry(assetGuid).address = currentObj.name;
            }
        }
    }
}

#endif
