using System;
using System.Collections.Generic;
using Core.Containers;
using Core.Models;
using Ui;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Init.Startups
{
    public class GameplayStartup : MonoBehaviour
    {
        private GameFieldModel _gameFieldModel;
        private PrefabsContainer _prefabsContainer;
        private readonly Dictionary<CellModel, CellGUIViewLogic> _logics = new();
        void Awake()
        {
            _gameFieldModel = ProjectContext.Instance.Container.Resolve<GameFieldModel>();
            _prefabsContainer = ProjectContext.Instance.Container.Resolve<PrefabsContainer>();
            
            foreach (var cell in _gameFieldModel.CellsModels)
            {
                _logics[cell] = new CellGUIViewLogic(new CellGUIViewModel(cell),
                    Instantiate(_prefabsContainer.CellView).GetComponent<CellView>());
            }
        }

        private void OnDestroy()
        {
            foreach (var cell in _gameFieldModel.CellsModels)
            {
                _logics[cell].DeInitialize();
            }
            _logics.Clear();
        }
    }
}
