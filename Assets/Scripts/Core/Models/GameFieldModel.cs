using System.Linq;
using Core.Services;
using UnityEngine;

namespace Core.Models
{
    public class GameFieldModel
    {
        private readonly IGameFieldGeneratorService _gameFieldGeneratorService;

        public GameFieldModel(IGameFieldGeneratorService gameFieldGeneratorService)
        {
            _gameFieldGeneratorService = gameFieldGeneratorService;
        }

        public CellModel[,] CellsModels { get; private set; }

        public int Width => CellsModels.GetLength(0);
        public int Height => CellsModels.GetLength(1);

        public int Generate(int width, int height)
        {
            CellsModels = new CellModel[width, height];
            var bombs = _gameFieldGeneratorService.Generate(width, height);
            var bombCount = 0;
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                var position = new Vector2Int(i, j);
                var bombInfo = bombs[position];
                if (bombInfo.HasBomb)
                {
                    bombCount++;
                }
                CellsModels[i, j] =
                    new CellModel(ECellState.Hidden, bombInfo.HasBomb, position, bombInfo.BombsAroundCount);
            }

            return bombCount;
        }

        public void CheckCellClick(Vector2Int clickPosition)
        {
            var cell = CellsModels[clickPosition.x, clickPosition.y];
            if (cell.HasBomb)
            {
                foreach (var cellModel in CellsModels)
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