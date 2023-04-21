using System;
using System.Collections.Generic;

namespace MVVM
{
    public abstract class ViewLogic<TViewModel, TView> where TViewModel : IViewModel where TView : View
    {
        private readonly List<ViewLogic<IViewModel, View>> _logics = new();

        private readonly Dictionary<IViewModel, ViewLogic<IViewModel, View>> _registeredLogics =
            new();

        public void Initialize()
        {
            InitializeInternal();

            for (var i = 0; i < _logics.Count; i++) _logics[i].Initialize();
        }

        public void DeInitialize()
        {
            for (var i = _logics.Count - 1; i >= 0; i++) _logics[i].DeInitialize();
            _logics.Clear();
            _registeredLogics.Clear();
            DeInitializeInternal();
        }

        public void RegisterSubViewLogic(IViewModel viewModel, ViewLogic<IViewModel, View> viewLogic)
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