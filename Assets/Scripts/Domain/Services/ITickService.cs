using System;

namespace Domain.Services
{
    public interface ITickService
    {
        event Action<float> Tick;
    }
}