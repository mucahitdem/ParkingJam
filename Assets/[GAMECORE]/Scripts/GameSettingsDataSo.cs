#if UNITY_EDITOR
using GAME.Scripts;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "BaseGame/Data/GameSettings", order = 0)]
    public class GameSettingsDataSo : ScriptableObject
    {
        public bool isLogsEnabled;
        public bool autoStartViaLoader;

        private void OnValidate()
        {
            if (isLogsEnabled)
                DefineSymbolsManager.AddDefineSymbol(Defs.DEFINE_SYMBOLS_ENABLE_LOG);
            else
                DefineSymbolsManager.RemoveDefineSymbol(Defs.DEFINE_SYMBOLS_ENABLE_LOG);
        }

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static GameSettingsDataSo s_instance;

        public static GameSettingsDataSo Instance => s_instance ??= Resources.Load<GameSettingsDataSo>("GameSettings");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllSkillData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}
#endif