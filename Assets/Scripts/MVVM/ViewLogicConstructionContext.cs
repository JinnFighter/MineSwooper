namespace MVVM
{
    public struct ViewLogicConstructionContext
    {
        public ViewLogicConstructionContext(IViewModel viewModel, View view, IViewLogicService viewLogicService)
        {
            ViewModel = viewModel;
            View = view;
            ViewLogicService = viewLogicService;
        }

        public IViewModel ViewModel { get; }
        public View View { get; }
        public IViewLogicService ViewLogicService { get; }
        
    }
}
