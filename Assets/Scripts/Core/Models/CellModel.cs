using Reactivity;

namespace Core.Models
{
    public class CellModel
    {
        public CellModel(ECellState cellState, bool hasBomb)
        {
            CellState = new ReactiveProperty<ECellState>(cellState);
            HasBomb = hasBomb;
        }

        private IReactiveProperty<ECellState> CellState { get; }

        public bool HasBomb { get; }
    }
}