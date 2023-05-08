using System.Collections.Generic;
using Core.Services;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Models
{
    public class GameFieldModel
    {
        public CellModel[,] CellsModels { get; private set; }

        public int Width => CellsModels.GetLength(0);
        public int Height => CellsModels.GetLength(1);

        public UnityEvent<Vector2Int> CellClicked { get; } = new();

        public CellModel this[Vector2Int position] => CellsModels[position.x, position.y];

        public void Generate(int width, int height,
            Dictionary<Vector2Int, IGameFieldGeneratorService.CellData> cellDatas)
        {
            CellsModels = new CellModel[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                var position = new Vector2Int(i, j);
                var bombInfo = cellDatas[position];
                CellsModels[i, j] =
                    new CellModel(ECellState.Hidden, bombInfo.HasBomb, position, bombInfo.BombsAroundCount);
            }
        }

        public IEnumerable<CellModel> GetNearestCells(Vector2Int position)
        {
            var nearestCells = new List<CellModel>();
            for (var i = Mathf.Clamp(position.x - 1, 0, Width);
                 i < Mathf.Clamp(position.x + 1, 0, Width);
                 i++)
            for (var j = Mathf.Clamp(position.y - 1, 0, Height);
                 j < Mathf.Clamp(position.y + 1, 0, Height);
                 j++)
            {
                var pos = new Vector2Int(i, j);
                if (pos == position) continue;

                nearestCells.Add(CellsModels[pos.x, pos.y]);
            }

            return nearestCells;
        }

        public void CheckCellClick(Vector2Int clickPosition)
        {
            CellClicked?.Invoke(clickPosition);
        }
    }
}