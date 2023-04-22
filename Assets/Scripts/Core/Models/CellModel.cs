using Reactivity;
using UnityEngine;

namespace Core.Models
{
    public class CellModel
    {
        public CellModel(ECellState cellState, bool hasBomb, Vector2Int gridPosition)
        {
            CellState = new ReactiveProperty<ECellState>(cellState);
            HasBomb = hasBomb;
            BombsAroundCount = new ReactiveProperty<int>();
            GridPosition = gridPosition;
        }

        public IReactiveProperty<ECellState> CellState { get; }

        public bool HasBomb { get; }
        public IReactiveProperty<int> BombsAroundCount { get; }
        public Vector2Int GridPosition { get; }
    }
}