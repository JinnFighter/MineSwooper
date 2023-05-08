using System;
using Core.Containers;
using Core.Models;
using MVVM;
using Reactivity;
using UnityEngine.EventSystems;
using Zenject;

namespace Ui
{
    public class CellGUIViewLogic : ViewLogic<ICellGUIViewModel, CellView>
    {
        private SpritesContainer _spritesContainer;
        protected override void InitializeInternal()
        {
            _spritesContainer = ProjectContext.Instance.Container.Resolve<SpritesContainer>();
            SubscriptionAggregator.ListenEvent(ViewModel.CellState, HandleCellStateChanged, true);
            SubscriptionAggregator.ListenEvent(View.CellClicked, HandleCellButtonClicked);
        }

        private void HandleCellStateChanged(object sender, GenericEventArg<ECellState> e)
        {
            switch (e.Value)
            {
                case ECellState.Hidden:
                    View.ClickableImage.gameObject.SetActive(true);
                    View.ClickableImage.sprite = _spritesContainer.HiddenSprite;
                    break;
                case ECellState.Marked:
                    View.ClickableImage.gameObject.SetActive(true);
                    View.ClickableImage.sprite = _spritesContainer.MarkedSprite;
                    break;
                case ECellState.HasBomb:
                    View.ClickableImage.gameObject.SetActive(false);
                    View.BombCountText.gameObject.SetActive(false);
                    View.OpenedImage.sprite = _spritesContainer.BombSprite;
                    break;
                case ECellState.Opened:
                    View.ClickableImage.gameObject.SetActive(false);
                    View.BombCountText.gameObject.SetActive(ViewModel.BombsAroundCount.Value > 0);
                    if (ViewModel.BombsAroundCount.Value > 0)
                        View.BombCountText.text = $"{ViewModel.BombsAroundCount.Value}";

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleCellButtonClicked(PointerEventData e)
        {
            ViewModel.ClickCell();
        }
    }
}