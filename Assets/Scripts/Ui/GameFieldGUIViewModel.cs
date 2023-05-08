using Core.Models;
using UnityEngine;

namespace Ui
{
    public class GameFieldGUIViewModel : IGameFieldGUIViewModel
    {
        private readonly GameFieldModel _gameFieldModel;

        public GameFieldGUIViewModel(GameFieldModel gameFieldModel)
        {
            _gameFieldModel = gameFieldModel;
            var cellModels = gameFieldModel.CellsModels;
            Cells = new ICellGUIViewModel[_gameFieldModel.Width, _gameFieldModel.Height];
            for (var i = 0; i < _gameFieldModel.Width; i++)
            for (var j = 0; j < _gameFieldModel.Height; j++)
                Cells[i, j] = new CellGUIViewModel(cellModels[i, j]);
        }

        public ICellGUIViewModel[,] Cells { get; }

        public void HandleCellClicked(Vector2Int position)
        {
            _gameFieldModel.CheckCellClick(position);
        }

        public void TryMarkCell(Vector2Int position)
        {
            _gameFieldModel.TryMarkCell(position);
        }
    }
}