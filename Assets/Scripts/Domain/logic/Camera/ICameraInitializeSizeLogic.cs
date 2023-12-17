using System;
using Domain.Logic.Startable;

namespace Domain.Logic.Camera
{
    public interface ICameraInitializeSizeLogic : IStartableLogic
    {
        void SetParameters(float cameraSize, float aspectRatio);
        event Action StartInitialize;
    }
}