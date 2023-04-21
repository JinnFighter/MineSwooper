namespace MVVM
{
    public abstract class ViewLogic<TViewModel, TView> where TViewModel : IViewModel where TView : View
    {
        public void Initialize()
        {
            InitializeInternal();
        }

        public void DeInitialize()
        {
            DeInitializeInternal();
        }

        protected virtual void InitializeInternal()
        {
        }

        protected virtual void DeInitializeInternal()
        {
        }
    }
}