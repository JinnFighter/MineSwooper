using Core.Models;
using UnityEngine;

namespace Ui
{
    public class GameFieldGUIViewModel : IGameFieldGUIViewModel
    {
        public GameFieldGUIViewModel(GameFieldModel gameFieldModel)
        {
            var cellModels = gameFieldModel.CellsModels;
            var width = cellModels.GetLength(0);
            var height = cellModels.GetLength(1);
            Cells = new ICellGUIViewModel[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                Cells[i, j] = new CellGUIViewModel(cellModels[i, j]);
        }

        public ICellGUIViewModel[,] Cells { get; }
        public void HandleCellClicked(Vector2Int position)
        {
            Debug.Log($"clicked cell at : {position}");
        }
    }
}