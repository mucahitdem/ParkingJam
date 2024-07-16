using GAME.Scripts;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.GameStateManagement.States
{
    public class WinState : IGameState
    {
        public void OnEnter()
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_WIN_SCREEN);
        }

        public void OnExit()
        {
            UiActionManager.hideUiItem?.Invoke(Defs.UI_KEY_WIN_SCREEN);
        }
    }
}