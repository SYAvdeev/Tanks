using System;

namespace Domain.Services.Input
{
    public interface IInputService
    {
        event Action<InputType> OnInput;
    }
}