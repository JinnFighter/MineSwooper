using System.Collections.Generic;
using System.Linq;
using Core.Services;
using Reactivity;
using UnityEngine;

namespace Core.Models
{
    public class GameplayModel
    {
        private readonly ReactiveProperty<int> _currentBombCount = new();
        private readonly IGameFieldGeneratorService _gameFieldGeneratorService;
        private readonly ReactiveProperty<EGameplayState> _gameplayState = new(EGameplayState.Playing);
        private readonly Dictionary<Vector2Int, int> _searchDict = new();
        private bool _isGameActive;

        public GameplayModel(GameFieldModel gameFieldModel, IGameFieldGeneratorService gameFieldGeneratorService)
        {
            GameFieldModel = gameFieldModel;
            _gameFieldGeneratorService = gameFieldGeneratorService;
        }

        public IReactiveProperty<EGameplayState> GameplayState => _gameplayState;

        public IReactiveProperty<int> CurrentBombCount => _currentBombCount;

        public int BombCount { get; private set; }
        public GameFieldModel GameFieldModel { get; }

        public void SetGameActive(bool isActive)
        {
            if (_isGameActive == isActive) return;

            if (isActive)
            {
                GameFieldModel.CellClicked.AddListener(CheckClickedCell);
                GameFieldModel.CellMarked.AddListener(CheckCellMarked);
            }
            else
            {
                GameFieldModel.CellClicked.RemoveListener(CheckClickedCell);
                GameFieldModel.CellMarked.RemoveListener(CheckCellMarked);
            }

            _isGameActive = isActive;
        }

        private void CheckCellMarked(Vector2Int arg0)
        {
            var cell = GameFieldModel[arg0];
            switch (cell.CellState.Value)
            {
                case ECellState.Opened:
                    break;
                case ECellState.Hidden:
                    cell.SetState(ECellState.Marked);
                    _currentBombCount.Value--;
                    break;
                case ECellState.Marked:
                    _currentBombCount.Value++;
                    cell.SetState(ECellState.Hidden);
                    break;
            }
        }

        public void GenerateGameData(int width, int height)
        {
            var cellDatas = _gameFieldGeneratorService.Generate(width, height);
            BombCount = cellDatas.Count(cellData => cellData.Value.HasBomb);
            _currentBombCount.Value = BombCount;
            GameFieldModel.Generate(width, height, cellDatas);
        }

        private void CheckClickedCell(Vector2Int position)
        {
            if (!_isGameActive) return;
            var cell = GameFieldModel[position];

            if (cell.HasBomb)
            {
                foreach (var cellModel in GameFieldModel.CellsModels)
                    if (cellModel.HasBomb)
                        cellModel.SetState(ECellState.HasBomb);
                _gameplayState.Value = EGameplayState.GameOver;
            }
            else
            {
                _searchDict.Clear();
                OpenCells(position);
            }
        }

        private void OpenCells(Vector2Int position)
        {
            var cell = GameFieldModel[position];
            if (cell.CellState.Value == ECellState.Opened) return;
            if (_searchDict.ContainsKey(position)) return;

            cell.SetState(ECellState.Opened);
            _searchDict.TryAdd(position, cell.BombsAroundCount.Value);
            if (cell.BombsAroundCount.Value > 0) return;

            foreach (var cellModel in GameFieldModel.GetNearestCells(position)
                         .Where(cellModel => !_searchDict.TryGetValue(cellModel.GridPosition, out _)))
                OpenCells(cellModel.GridPosition);
        }
    }
}