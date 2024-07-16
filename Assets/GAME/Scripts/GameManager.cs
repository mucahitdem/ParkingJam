using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.GameStateManagement.States;
using Scripts.BaseGameScripts.Helper;
using Scripts.ServiceLocatorModule;

namespace GAME.Scripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        private GameStateManager _gameStateManager;
        protected override void OnAwake()
        {
            _gameStateManager = ServiceLocator.Instance.GetService<GameStateManager>();
            _gameStateManager.SetState(new StartState());
        }
    }
}