namespace Domain.Logic.Transformable
{
    public interface IMoveRestrictionLogic : ILogic
    {
        void Restrict(ref float x, ref float y);
    }
}