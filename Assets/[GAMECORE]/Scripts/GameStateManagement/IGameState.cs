namespace Scripts.BaseGameScripts.GameStateManagement
{
    public interface IGameState
    {
        void OnEnter();
        void OnExit();
    }
}