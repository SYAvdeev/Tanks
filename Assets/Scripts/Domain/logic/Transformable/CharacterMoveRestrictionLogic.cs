using System;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class CharacterMoveRestrictionLogic : IMoveRestrictionLogic
    {
        private readonly IReactivePropertyReadonly<float> _cameraSizeXProperty;
        private readonly IReactivePropertyReadonly<float> _cameraSizeYProperty;

        public CharacterMoveRestrictionLogic(
            IReactivePropertyReadonly<float> cameraSizeXProperty,
            IReactivePropertyReadonly<float> cameraSizeYProperty)
        {
            _cameraSizeXProperty = cameraSizeXProperty;
            _cameraSizeYProperty = cameraSizeYProperty;
        }

        public void Restrict(ref float x, ref float y)
        {
            x = Math.Clamp(x, 0f, _cameraSizeXProperty.Value);
            y = Math.Clamp(y, 0f, _cameraSizeYProperty.Value);
        }
    }
}