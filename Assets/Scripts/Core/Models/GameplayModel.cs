using System.Collections.Generic;
using System.Linq;
using Core.Services;
using UnityEngine;

namespace Core.Models
{
    public class GameplayModel
    {
        private readonly IGameFieldGeneratorService _gameFieldGeneratorService;
        private readonly Dictionary<Vector2Int, int> _searchDict = new();
        private bool _isGameActive;

        public GameplayModel(GameFieldModel gameFieldModel, IGameFieldGeneratorService gameFieldGeneratorService)
        {
            GameFieldModel = gameFieldModel;
            _gameFieldGeneratorService = gameFieldGeneratorService;
        }

        public int BombCount { get; private set; }
        public GameFieldModel GameFieldModel { get; }

        public void SetGameActive(bool isActive)
        {
            if (_isGameActive == isActive) return;

            if (isActive)
                GameFieldModel.CellClicked.AddListener(CheckClickedCell);
            else
                GameFieldModel.CellClicked.RemoveListener(CheckClickedCell);
            _isGameActive = isActive;
        }

        public void GenerateGameData(int width, int height)
        {
            var cellDatas = _gameFieldGeneratorService.Generate(width, height);
            BombCount = cellDatas.Count(cellData => cellData.Value.HasBomb);
            GameFieldModel.Generate(width, height, cellDatas);
        }

        public void CheckClickedCell(Vector2Int position)
        {
            if (!_isGameActive) return;
            var cell = GameFieldModel[position];

            if (cell.HasBomb)
            {
                foreach (var cellModel in GameFieldModel.CellsModels)
                    if (cellModel.HasBomb)
                        cellModel.SetState(ECellState.HasBomb);
                Debug.Log("Game over!");
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