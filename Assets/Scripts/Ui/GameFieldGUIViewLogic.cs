using MVVM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui
{
    public class GameFieldGUIViewLogic : ViewLogic<IGameFieldGUIViewModel, GameFieldView>
    {
        protected override void InitializeInternal()
        {
            foreach (var cellGUIViewModel in ViewModel.Cells)
                SubscriptionAggregator.ListenEvent(cellGUIViewModel.CellClicked, HandleCellClicked);
        }

        private void HandleCellClicked(Vector2Int arg0, PointerEventData pointerEventData)
        {
            switch (pointerEventData.button)
            {
                case PointerEventData.InputButton.Left:
                    ViewModel.HandleCellClicked(arg0);
                    break;
                case PointerEventData.InputButton.Right:
                    ViewModel.TryMarkCell(arg0);
                    break;
            }
        }

        protected override void AssembleSubViewLogics()
        {
            foreach (var cellViewModel in ViewModel.Cells)
                RegisterSubViewLogic<CellGUIViewLogic, CellView>(cellViewModel, "CellView", View.CellsParent.transform);
        }
    }
}