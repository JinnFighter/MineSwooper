using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public class ViewLogicService : IViewLogicService
    {
        public ViewFactory ViewFactory { get; private set; }

        public UniTask Initialize()
        {
            ViewFactory = new ViewFactory(Resources.Load<PrefabsContainer>("PrefabsContainer"));
            return UniTask.CompletedTask;
        }

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