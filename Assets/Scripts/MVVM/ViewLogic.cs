using System;
using System.Collections.Generic;
using Subscription;
using UnityEngine;

namespace MVVM
{
    public abstract class BaseViewLogic
    {
        public abstract void Initialize();
        public abstract void DeInitialize();
        public abstract void Construct(ViewLogicConstructionContext constructionContext);
    }

    public abstract class ViewLogic<TViewModel, TView> : BaseViewLogic where TViewModel : IViewModel where TView : View
    {
        private readonly List<BaseViewLogic> _logics = new();

        private readonly Dictionary<IViewModel, BaseViewLogic> _registeredLogics =
            new();

        protected SubscriptionAggregator SubscriptionAggregator { get; } = new();
        protected TViewModel ViewModel { get; private set; }
        protected TView View { get; private set; }
        private IViewLogicService ViewLogicService { get; set; }

        public override void Initialize()
        {
            InitializeInternal();
            AssembleSubViewLogics();
            for (var i = 0; i < _logics.Count; i++) _logics[i].Initialize();
        }

        public override void DeInitialize()
        {
            SubscriptionAggregator.Unsubscribe();
            for (var i = _logics.Count - 1; i >= 0; i--) _logics[i].DeInitialize();
            _logics.Clear();
            _registeredLogics.Clear();
            DeInitializeInternal();
        }

        public override void Construct(ViewLogicConstructionContext constructionContext)
        {
            ViewModel = (TViewModel)constructionContext.ViewModel;
            View = (TView)constructionContext.View;
            ViewLogicService = constructionContext.ViewLogicService;
        }

        protected void RegisterSubViewLogic<TViewLogic, TView>(IViewModel viewModel, TView view)
            where TViewLogic : BaseViewLogic where TView : View
        {
            if (_registeredLogics.ContainsKey(viewModel))
                throw new Exception(
                    $"Error tyring to bind {typeof(TViewLogic)} to model {viewModel.GetType()} : ViewLogic is already registered!");

            var viewLogic = ViewLogicService.CreateViewLogic<TViewLogic, TView>(viewModel, view);
            _registeredLogics.Add(viewModel, viewLogic);
            _logics.Add(viewLogic);
        }

        protected void RegisterSubViewLogic<TViewLogic, TView>(IViewModel viewModel, string key, Transform parentTransform = null)
            where TViewLogic : BaseViewLogic where TView : View
        {
            if (_registeredLogics.ContainsKey(viewModel))
                throw new Exception(
                    $"Error tyring to bind {typeof(TViewLogic)} to model {viewModel.GetType()} : ViewLogic is already registered!");

            var viewLogic = ViewLogicService.CreateViewLogic<TViewLogic, TView>(viewModel, key, parentTransform);
            _registeredLogics.Add(viewModel, viewLogic);
            _logics.Add(viewLogic);
        }

        protected virtual void AssembleSubViewLogics()
        {
        }

        protected virtual void InitializeInternal()
        {
        }

        protected virtual void DeInitializeInternal()
        {
        }
    }
}