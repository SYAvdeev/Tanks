namespace Features
{
    public interface IViewsContainer
    {
        ViewModelsCollection ViewModels { get; }
        ViewLogicCollection ViewsLogic { get; }
    }
}