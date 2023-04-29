using System;

namespace MVVM
{
    public class ViewLogicService : IViewLogicService
    {
        public ViewLogicService(ViewFactory viewFactory)
        {
            ViewFactory = viewFactory;
        }

        public ViewFactory ViewFactory { get; }

        public TViewLogic CreateViewLogic<TViewLogic, TView>(IViewModel viewModel, string viewKey)
            where TViewLogic : BaseViewLogic where TView : View
        {
            return Activator.CreateInstance(typeof(TViewLogic), viewModel, ViewFactory.GetView<TView>(viewKey)) as
                TViewLogic;
        }

        public TViewLogic CreateViewLogic<TViewLogic, TView>(IViewModel viewModel, TView view)
            where TViewLogic : BaseViewLogic where TView : View
        {
            return Activator.CreateInstance(typeof(TViewLogic), viewModel, view) as
                TViewLogic;
        }
    }
}