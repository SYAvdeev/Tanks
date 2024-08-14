﻿using Tanks.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.LevelObjects.Level
{
    public interface ILevelConfig
    {
        SpawnableConfig SpawnableConfig { get; }
        LevelView LevelViewPrefab { get; }
        Vector2 MinPosition { get; }
        Vector2 MaxPosition { get; }
    }
}