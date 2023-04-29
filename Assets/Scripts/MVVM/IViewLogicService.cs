namespace MVVM
{
    public interface IViewLogicService
    {
        ViewFactory ViewFactory { get; }

        TViewLogic CreateViewLogic<TViewLogic, TView>(IViewModel viewModel, string viewKey) where TViewLogic : BaseViewLogic where TView : View;
        TViewLogic CreateViewLogic<TViewLogic, TView>(IViewModel viewModel, TView view) where TViewLogic : BaseViewLogic where TView : View;
    }
}