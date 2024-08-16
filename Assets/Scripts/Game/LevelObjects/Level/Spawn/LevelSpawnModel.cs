using System;
using System.Collections.Generic;
using System.Linq;

namespace Tanks.Game.LevelObjects.Level
{
    public class LevelSpawnModel : ILevelSpawnModel
    {
        private readonly LevelSpawnData _levelSpawnData;

        public LevelSpawnModel(LevelSpawnData levelSpawnData, ILevelSpawnConfig config)
        {
            _levelSpawnData = levelSpawnData;
            Config = config;
        }

        public ILevelSpawnConfig Config { get; }

        public IDictionary<string, ILevelModel> LevelsPool { get; } = new Dictionary<string, ILevelModel>();

        public ILevelModel CurrentLevelModel { get; private set; }

        public event Action<ILevelModel> CurrentLevelChanged;

        public bool IsCurrentLevelIDEmpty => string.IsNullOrEmpty(_levelSpawnData.CurrentLevelID);

        public ILevelConfig CurrentLevelConfig
        {
            get
            {
                return IsCurrentLevelIDEmpty
                    ? null
                    : Config.LevelConfigs.FirstOrDefault(
                        lc => lc.SpawnableConfig.ID == _levelSpawnData.CurrentLevelID);
            }
        }

        void ILevelSpawnModel.SetCurrentLevel(ILevelModel levelModel)
        {
            if (CurrentLevelModel != null)
            {
                if(CurrentLevelModel == levelModel)
                {
                    return;
                }

                LevelsPool[CurrentLevelModel.Spawnable.Config.ID] = CurrentLevelModel;
            }
            
            _levelSpawnData.CurrentLevelID = levelModel.Spawnable.Config.ID;
            CurrentLevelModel = levelModel;
            CurrentLevelChanged?.Invoke(levelModel);
        }
    }
}