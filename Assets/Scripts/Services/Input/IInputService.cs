using System;

namespace Services.Input
{
    public interface IInputService
    {
        event Action<InputType> OnInput;
    }
}