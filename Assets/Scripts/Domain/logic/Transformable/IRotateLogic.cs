using Domain.Logic.Tickable;

namespace Domain.Logic.Transformable
{
    public interface IRotateLogic : ITickableLogic
    {
        bool IsClockwise { set; }
    }
}