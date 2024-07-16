using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;

namespace Scripts.BaseGameScripts.GameStateManagement
{
    public class GameStateManager : BaseComponent
    {
        private IGameState _currentState;

        public void SetState(IGameState gameState)
        {
            _currentState?.OnExit();

            //DebugHelper.LogGreen("GAME STATE : " + gameState.ToString());
            _currentState = gameState;
            _currentState.OnEnter();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
        }
    }
}