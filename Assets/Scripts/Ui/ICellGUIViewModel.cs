using Core.Models;
using MVVM;
using Reactivity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Ui
{
    public interface ICellGUIViewModel : IViewModel
    {
        IReactiveProperty<ECellState> CellState { get; }
        IReactiveProperty<int> BombsAroundCount { get; }
        bool HasBomb { get; }
        Vector2Int GridPosition { get; }
        UnityEvent<Vector2Int, PointerEventData> CellClicked { get; }
        void ClickCell(PointerEventData pointerEventData);
    }
}