using System;
using Core.Containers;
using Core.Models;
using MVVM;
using Reactivity;
using Zenject;

namespace Ui
{
    public class CellGUIViewLogic : ViewLogic<ICellGUIViewModel, CellView>
    {
        private SpritesContainer _spritesContainer;
        public CellGUIViewLogic(ICellGUIViewModel viewModel, CellView view) : base(viewModel, view)
        {
        }

        protected override void InitializeInternal()
        {
            _spritesContainer = ProjectContext.Instance.Container.Resolve<SpritesContainer>();
            SubscriptionAggregator.ListenEvent(ViewModel.CellState, HandleCellStateChanged, true);
            SubscriptionAggregator.ListenEvent(View.CellButton.onClick, HandleCellButtonClicked);
        }

        private void HandleCellStateChanged(object sender, GenericEventArg<ECellState> e)
        {
            switch (e.Value)
            {
                case ECellState.Hidden:
                    View.EmptyImage.gameObject.SetActive(true);
                    View.EmptyImage.sprite = _spritesContainer.EmptySprite;
                    break;
                case ECellState.Marked:
                    View.EmptyImage.gameObject.SetActive(true);
                    View.EmptyImage.sprite = _spritesContainer.MarkedSprite;
                    break;
                case ECellState.HasBomb:
                    View.EmptyImage.gameObject.SetActive(false);
                    View.BombCountText.gameObject.SetActive(false);
                    View.OpenedImage.sprite = _spritesContainer.BombSprite;
                    break;
                case ECellState.Opened:
                    View.EmptyImage.gameObject.SetActive(false);
                    View.BombCountText.gameObject.SetActive(ViewModel.BombsAroundCount.Value > 0);
                    if (ViewModel.BombsAroundCount.Value > 0)
                        View.BombCountText.text = $"{ViewModel.BombsAroundCount.Value}";

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleCellButtonClicked()
        {
            ViewModel.ClickCell();
        }
    }
}