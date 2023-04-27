using Reactivity;
using UnityEngine;

namespace Core.Models
{
    public class CellModel
    {
        private readonly ReactiveProperty<ECellState> _cellState;

        public CellModel(ECellState cellState, bool hasBomb, Vector2Int gridPosition, int bombsAroundCount)
        {
            _cellState = new ReactiveProperty<ECellState>(cellState);
            HasBomb = hasBomb;
            BombsAroundCount = new ReactiveProperty<int>(bombsAroundCount);
            GridPosition = gridPosition;
        }

        public IReactiveProperty<ECellState> CellState => _cellState;

        public bool HasBomb { get; }
        public IReactiveProperty<int> BombsAroundCount { get; }
        public Vector2Int GridPosition { get; }

        public void SetState(ECellState cellState)
        {
            _cellState.Value = cellState;
        }
    }
}