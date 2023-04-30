using System.Linq;
using Core.Services;
using UnityEngine;

namespace Core.Models
{
    public class GameplayModel
    {
        private readonly IGameFieldGeneratorService _gameFieldGeneratorService;

        public GameplayModel(GameFieldModel gameFieldModel, IGameFieldGeneratorService gameFieldGeneratorService)
        {
            GameFieldModel = gameFieldModel;
            _gameFieldGeneratorService = gameFieldGeneratorService;
        }

        public int BombCount { get; private set; }
        public GameFieldModel GameFieldModel { get; }

        public void GenerateGameData(int width, int height)
        {
            var cellDatas = _gameFieldGeneratorService.Generate(width, height);
            BombCount = cellDatas.Count(cellData => cellData.Value.HasBomb);
            GameFieldModel.Generate(width, height, cellDatas);
        }

        public void CheckClickedCell(Vector2Int position)
        {
            var cell = GameFieldModel.CellsModels[position.x, position.y];
            if (cell.HasBomb)
            {
                foreach (var cellModel in GameFieldModel.CellsModels)
                    cellModel.SetState(cellModel.HasBomb ? ECellState.HasBomb : ECellState.Opened);
                Debug.Log("Game over!");
            }
            else
            {
                cell.SetState(ECellState.Opened);
            }
        }
    }
}