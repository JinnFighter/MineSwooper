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
                CellsModels[i, j] = new CellModel(ECellState.Hidden, false, new Vector2Int(i, j));
        }

        public CellModel[,] CellsModels { get; }

        public int Width => CellsModels.GetLength(0);
        public int Height => CellsModels.GetLength(1);

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