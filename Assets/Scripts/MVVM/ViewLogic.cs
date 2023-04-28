using System;
using System.Collections.Generic;
using Subscription;

namespace MVVM
{
    public abstract class BaseViewLogic
    {
        public abstract void Initialize();
        public abstract void DeInitialize();
    }
    public abstract class ViewLogic<TViewModel, TView> : BaseViewLogic where TViewModel : IViewModel where TView : View
    {
        private readonly List<BaseViewLogic> _logics = new();

        private readonly Dictionary<IViewModel, BaseViewLogic> _registeredLogics =
            new();

        protected ViewLogic(TViewModel viewModel, TView view)
        {
            ViewModel = viewModel;
            View = view;
        }

        protected SubscriptionAggregator SubscriptionAggregator { get; } = new();
        protected TViewModel ViewModel { get; }
        protected TView View { get; }

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

        public void RegisterSubViewLogic(IViewModel viewModel, BaseViewLogic viewLogic)
        {
            if (_registeredLogics.TryAdd(viewModel, viewLogic))
                _logics.Add(viewLogic);
            else
                throw new Exception(
                    $"Error tyring to bind {viewLogic.GetType()} to model {viewModel.GetType()} : ViewLogic is already registered!");
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