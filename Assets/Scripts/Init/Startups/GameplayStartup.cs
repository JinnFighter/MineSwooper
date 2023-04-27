using Core.Models;
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

            _gameFieldModel.Generate(5, 5);

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