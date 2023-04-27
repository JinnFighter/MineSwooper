using MVVM;
using UnityEngine;

namespace Ui
{
    public interface IGameFieldGUIViewModel : IViewModel
    {
        ICellGUIViewModel[,] Cells { get; }

        void HandleCellClicked(Vector2Int position);
    }
}