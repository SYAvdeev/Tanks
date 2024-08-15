namespace Tanks.UI
{
    public interface IUIConfig
    {
        TScreen GetUIPrefabByType<TScreen>() where TScreen : UIScreen;
    }
}