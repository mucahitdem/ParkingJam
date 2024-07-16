using GAME.Scripts;
using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.UiManagement;

namespace Scripts.GameStateManagement.States
{
    public class GamePlayState : IGameState
    {
        public void OnEnter()
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_GAME_PLAY_SCREEN);
            //SoundManager.Instance.PlayAudio(Defs.AUDIO_GAME_START);
        }

        public void OnExit()
        {
            UiActionManager.hideUiItem?.Invoke(Defs.UI_KEY_GAME_PLAY_SCREEN);
        }
    }
}