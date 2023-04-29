namespace MVVM
{
    public class ViewLogicService : IViewLogicService
    {
        public ViewLogicService(ViewFactory viewFactory)
        {
            ViewFactory = viewFactory;
        }

        public ViewFactory ViewFactory { get; }
    }
}