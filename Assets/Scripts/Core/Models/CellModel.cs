using Reactivity;
using UnityEngine;

namespace Core.Models
{
    public class CellModel
    {
        private readonly ReactiveProperty<ECellState> _cellState;

        public CellModel(ECellState cellState, bool hasBomb, Vector2Int gridPosition)
        {
            _cellState = new ReactiveProperty<ECellState>(cellState);
            HasBomb = hasBomb;
            BombsAroundCount = new ReactiveProperty<int>();
            GridPosition = gridPosition;
        }

        public IReactiveProperty<ECellState> CellState => _cellState;

        public bool HasBomb { get; private set; }
        public IReactiveProperty<int> BombsAroundCount { get; }
        public Vector2Int GridPosition { get; }

        public void PlantBomb()
        {
            HasBomb = true;
        }

        public void SetState(ECellState cellState)
        {
            _cellState.Value = cellState;
        }
    }
}