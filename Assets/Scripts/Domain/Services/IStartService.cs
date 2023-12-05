using System;

namespace Domain.Services
{
    public interface IStartService
    {
        event Action Start;
    }
}