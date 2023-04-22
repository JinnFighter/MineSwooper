using Core.Models;
using MVVM;
using Reactivity;

namespace Ui
{
    public class CellGUIViewLogic : ViewLogic<ICellGUIViewModel, CellView>
    {
        public CellGUIViewLogic(ICellGUIViewModel viewModel, CellView view) : base(viewModel, view)
        {
        }

        protected override void InitializeInternal()
        {
            SubscriptionAggregator.ListenEvent(ViewModel.CellState, HandleCellStateChanged, true);
            SubscriptionAggregator.ListenEvent(View.CellButton.onClick, HandleCellButtonClicked);
        }

        private void HandleCellStateChanged(object sender, GenericEventArg<ECellState> e)
        {
            switch (e.Value)
            {
                case ECellState.Hidden:
                    View.EmptyImage.gameObject.SetActive(true);
                    View.EmptyImage.sprite = View.EmptySprite;
                    break;
                case ECellState.Marked:
                    View.EmptyImage.gameObject.SetActive(true);
                    View.EmptyImage.sprite = View.MarkedSprite;
                    break;
                case ECellState.HasBomb:
                    View.EmptyImage.gameObject.SetActive(false);
                    View.BombCountText.gameObject.SetActive(false);
                    View.OpenedImage.sprite = View.BombSprite;
                    break;
                case ECellState.Opened:
                    View.EmptyImage.gameObject.SetActive(false);
                    View.BombCountText.gameObject.SetActive(ViewModel.BombsAroundCount.Value > 0);
                    if (ViewModel.BombsAroundCount.Value > 0)
                        View.BombCountText.text = $"{ViewModel.BombsAroundCount.Value}";

                    break;
            }
        }

        private void HandleCellButtonClicked()
        {
            ViewModel.ClickCell();
        }
    }
}