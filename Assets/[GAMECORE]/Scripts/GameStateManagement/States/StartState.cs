using GAME.Scripts;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.SoundManagement;

namespace Scripts.BaseGameScripts.GameStateManagement.States
{
    public class StartState : IGameState
    {
        public void OnEnter()
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_START_SCREEN);
        }

        public void OnExit()
        {
            UiActionManager.hideUiItem?.Invoke(Defs.UI_KEY_START_SCREEN);
        }
    }
}