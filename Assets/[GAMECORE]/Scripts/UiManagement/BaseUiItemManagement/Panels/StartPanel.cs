using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameStateManagement.States;
using Scripts.ServiceLocatorModule;
using UnityEngine.EventSystems;

namespace Scripts.UiManagement.BaseUiItemManagement.Panels
{
    public class StartPanel : BaseUiPanel, IPointerClickHandler
    {
        private GameStateManager _gameStateManager;

        public void OnPointerClick(PointerEventData eventData)
        {
            if(_gameStateManager == null)
                _gameStateManager = ServiceLocator.Instance.GetService<GameStateManager>();

            _gameStateManager.SetState(new GamePlayState());
        }
    }
}