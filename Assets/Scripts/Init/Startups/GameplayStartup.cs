using Core.Models;
using Core.Services;
using Ui;
using UnityEngine;
using Zenject;

namespace Init.Startups
{
    public class GameplayStartup : MonoBehaviour
    {
        [SerializeField] private GameFieldView _gameFieldView;
        private GameFieldGUIViewLogic _gameFieldGUIViewLogic;
        private GameFieldModel _gameFieldModel;

        private void Awake()
        {
            _gameFieldModel = ProjectContext.Instance.Container.Resolve<GameFieldModel>();

            var bombsGeneratorService = ProjectContext.Instance.Container.Resolve<IBombsGeneratorService>();

            var bombPositions = bombsGeneratorService.Generate(_gameFieldModel.Width, _gameFieldModel.Height);

            foreach (var bombPosition in bombPositions)
                _gameFieldModel.CellsModels[bombPosition.x, bombPosition.y].PlantBomb();

            _gameFieldGUIViewLogic =
                new GameFieldGUIViewLogic(new GameFieldGUIViewModel(_gameFieldModel), _gameFieldView);
            _gameFieldGUIViewLogic.Initialize();
        }

        private void OnDestroy()
        {
            _gameFieldGUIViewLogic.DeInitialize();
        }
    }
}