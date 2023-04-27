using Core.Models;
using Reactivity;
using UnityEngine;
using UnityEngine.Events;

namespace Ui
{
    public class CellGUIViewModel : ICellGUIViewModel
    {
        private readonly CellModel _model;

        public CellGUIViewModel(CellModel model)
        {
            _model = model;
        }

        public IReactiveProperty<ECellState> CellState => _model.CellState;
        public IReactiveProperty<int> BombsAroundCount => _model.BombsAroundCount;
        public bool HasBomb => _model.HasBomb;
        public Vector2Int GridPosition => _model.GridPosition;
        public UnityEvent<Vector2Int> CellClicked { get; } = new();

        public void ClickCell()
        {
            if (CellState.Value is not (ECellState.Opened and ECellState.HasBomb)) CellClicked?.Invoke(GridPosition);
        }
    }
}