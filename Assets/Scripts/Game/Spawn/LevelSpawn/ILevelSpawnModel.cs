using System;
using System.Collections.Generic;
using Tanks.Game.LevelObjects.Level;

namespace Tanks.Game.Spawn.LevelSpawn
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