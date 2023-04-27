using Core.Models;
using MVVM;
using Reactivity;
using UnityEngine;
using UnityEngine.Events;

namespace Ui
{
    public interface ICellGUIViewModel : IViewModel
    {
        IReactiveProperty<ECellState> CellState { get; }
        IReactiveProperty<int> BombsAroundCount { get; }
        bool HasBomb { get; }
        Vector2Int GridPosition { get; }
        UnityEvent<Vector2Int> CellClicked { get; }
        void ClickCell();
    }
}