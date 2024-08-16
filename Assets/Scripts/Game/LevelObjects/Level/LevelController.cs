namespace Tanks.Game.LevelObjects.Level
{
    public class LevelController
    {
        public ILevelModel Model { get; }
        public LevelView View { get; }

        public LevelController(ILevelModel model, LevelView view)
        {
            Model = model;
            View = view;
        }
    }
}