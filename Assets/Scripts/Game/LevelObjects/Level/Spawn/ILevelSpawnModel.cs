using System;
using System.Collections.Generic;

namespace Tanks.Game.LevelObjects.Level
{
    public interface ILevelSpawnModel
    {
        ILevelSpawnConfig Config { get; }
        IDictionary<string, ILevelModel> LevelsPool { get; }
        ILevelModel CurrentLevelModel { get; }
        event Action<ILevelModel> CurrentLevelChanged;
        bool IsCurrentLevelIDEmpty { get; }
        ILevelConfig CurrentLevelConfig { get; }
        internal void SetCurrentLevel(ILevelModel levelModel);
    }
}