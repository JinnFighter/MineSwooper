using System;
using UnityEngine;

namespace MVVM
{
    public class ViewLogicService : IViewLogicService
    {
        public ViewLogicService(ViewFactory viewFactory)
        {
            ViewFactory = viewFactory;
        }

        public ViewFactory ViewFactory { get; }

        public TViewLogic CreateViewLogic<TViewLogic, TView>(IViewModel viewModel, string viewKey,
            Transform parentTransform = null)
            where TViewLogic : BaseViewLogic where TView : View
        {
            var viewLogic = Activator.CreateInstance(typeof(TViewLogic)) as TViewLogic;
            viewLogic.Construct(new ViewLogicConstructionContext(viewModel,
                ViewFactory.GetView<TView>(viewKey, parentTransform), this));
            return viewLogic;
        }

        public TViewLogic CreateViewLogic<TViewLogic, TView>(IViewModel viewModel, TView view)
            where TViewLogic : BaseViewLogic where TView : View
        {
            var viewLogic = Activator.CreateInstance(typeof(TViewLogic)) as TViewLogic;
            viewLogic.Construct(new ViewLogicConstructionContext(viewModel,
                view, this));
            return viewLogic;
        }
    }
}