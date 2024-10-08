﻿using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public interface ICameraConfig
    {
        IMovableConfig MovableConfig { get; }
        float SizeY { get; }
    }
}