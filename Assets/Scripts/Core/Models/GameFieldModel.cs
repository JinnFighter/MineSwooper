using UnityEngine;

namespace Core.Models
{
    public class GameFieldModel
    {
        public GameFieldModel()
        {
            var width = 5;
            var height = 5;
            CellsModels = new CellModel[width, height];
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                CellsModels[i, j] = new CellModel(ECellState.Marked, false, new Vector2Int(i, j));
        }

        public CellModel[,] CellsModels { get; }

        public int Width => CellsModels.GetLength(0);
        public int Height => CellsModels.GetLength(1);
    }
}