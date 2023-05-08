using Core.Models;
using MVVM;
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
        private GameplayModel _gameplayModel;

        private void Awake()
        {
            _gameplayModel = ProjectContext.Instance.Container.Resolve<GameplayModel>();
            var gameFieldModel = _gameplayModel.GameFieldModel;

            _gameplayModel.GenerateGameData(5, 5);
            _gameplayModel.SetGameActive(true);
            var viewLogicService = ProjectContext.Instance.Container.Resolve<IViewLogicService>();

            _gameplayGUIViewLogic = viewLogicService.CreateViewLogic<GameplayGUIViewLogic, GameplayView>(
                new GameplayGUIViewModel(
                    new BombCountGUIViewModel(_gameplayModel.CurrentBombCount),
                    new GameFieldGUIViewModel(gameFieldModel), _gameplayModel.GameplayState), _gameplayView);

            _gameplayGUIViewLogic.Initialize();
        }

        private void OnDestroy()
        {
            _gameplayModel.SetGameActive(false);
            _gameplayGUIViewLogic.DeInitialize();
        }
    }
}