using MVVM;
using UnityEngine;

namespace Ui
{
    public class GameFieldGUIViewLogic : ViewLogic<IGameFieldGUIViewModel, GameFieldView>
    {
        protected override void InitializeInternal()
        {
            foreach (var cellGUIViewModel in ViewModel.Cells)
                SubscriptionAggregator.ListenEvent(cellGUIViewModel.CellClicked, HandleCellClicked);
        }

        private void HandleCellClicked(Vector2Int arg0)
        {
            ViewModel.HandleCellClicked(arg0);
        }

        protected override void AssembleSubViewLogics()
        {
            foreach (var cellViewModel in ViewModel.Cells)
                RegisterSubViewLogic<CellGUIViewLogic, CellView>(cellViewModel, "CellView", View.CellsParent.transform);
        }
    }
}