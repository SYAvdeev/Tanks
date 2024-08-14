﻿using Tanks.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.LevelObjects.Level
{
    [CreateAssetMenu(
        fileName = nameof(LevelConfig), 
        menuName = "Custom/LevelObjects/" + nameof(LevelConfig),
        order = 0)]
    public class LevelConfig : ConfigBase, ILevelConfig
    {
        [SerializeField] private SpawnableConfig _spawnableConfig;
        [SerializeField] private Vector2 _minPosition;
        [SerializeField] private Vector2 _maxPosition;
        [SerializeField] private LevelView _levelViewPrefab;

        public SpawnableConfig SpawnableConfig => _spawnableConfig;
        public Vector2 MinPosition => _minPosition;
        public Vector2 MaxPosition => _maxPosition;
        public LevelView LevelViewPrefab => _levelViewPrefab;
    }
}