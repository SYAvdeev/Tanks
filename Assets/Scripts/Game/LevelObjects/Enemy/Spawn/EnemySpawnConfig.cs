﻿using Tanks.Utility;
using UnityEngine;

namespace Tanks.Enemy
{
    [CreateAssetMenu(
        fileName = nameof(EnemySpawnConfig),
        menuName = "Custom/Game/LevelObjects/Spawn/" + nameof(EnemySpawnConfig),
        order = 1)]
    public class EnemySpawnConfig : ConfigBase, IEnemySpawnConfig
    {
        
    }
}