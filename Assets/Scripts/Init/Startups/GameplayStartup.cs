using Core.Models;
using Ui;
using UnityEngine;
using Zenject;

namespace Init.Startups
{
    public class GameplayStartup : MonoBehaviour
    {
        [SerializeField] private GameplayView _gameplayView;
        private GameFieldGUIViewLogic _gameFieldGUIViewLogic;
        private GameplayGUIViewLogic _gameplayGUIViewLogic;

        private void Awake()
        {
            var gameFieldModel = ProjectContext.Instance.Container.Resolve<GameFieldModel>();

            var bombCount = gameFieldModel.Generate(5, 5);

            _gameplayGUIViewLogic = new GameplayGUIViewLogic(new GameplayGUIViewModel(
                new BombCountGUIViewModel(bombCount),
                new GameFieldGUIViewModel(gameFieldModel)), _gameplayView);

            _gameplayGUIViewLogic.Initialize();
        }

        private void OnDestroy()
        {
            _gameplayGUIViewLogic.DeInitialize();
        }
    }
}