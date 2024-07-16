using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    [CreateAssetMenu(fileName = "AllSourceDataSo", menuName = "BaseGame/Data/AllSourceDataSo", order = 0)]
    public class AllSourceDataSo : ScriptableObject
    {
        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllSourceDataSo s_instance;

        public static AllSourceDataSo Instance => s_instance ??= Resources.Load<AllSourceDataSo>("AllSourceDataSo");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllLevels asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion

        public BaseSourceDataSo[] AllSources => allSources;
        
        [SerializeField]
        private BaseSourceDataSo[] allSources;
    }
}