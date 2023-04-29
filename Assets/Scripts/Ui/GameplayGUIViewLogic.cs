using MVVM;

namespace Ui
{
    public class GameplayGUIViewLogic : ViewLogic<IGameplayGUIViewModel, GameplayView>
    {
        public GameplayGUIViewLogic(IGameplayGUIViewModel viewModel, GameplayView view,
            IViewLogicService viewLogicService) : base(viewModel, view, viewLogicService)
        {
        }

        protected override void AssembleSubViewLogics()
        {
            RegisterSubViewLogic<GameFieldGUIViewLogic, GameFieldView>(ViewModel.GameFieldViewModel,
                View.GameFieldView);
            RegisterSubViewLogic<BombCountGUIViewLogic, BombCountView>(ViewModel.BombCountViewModel,
                View.BombCountView);
        }
    }
}