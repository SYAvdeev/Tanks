using System;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class CharacterMoveRestrictionLogic : IMoveRestrictionLogic
    {
        private readonly IReactivePropertyReadonly<float> _levelSizeXProperty;
        private readonly IReactivePropertyReadonly<float> _levelSizeYProperty;

        public CharacterMoveRestrictionLogic(
            IReactivePropertyReadonly<float> levelSizeXProperty,
            IReactivePropertyReadonly<float> levelSizeYProperty)
        {
            _levelSizeXProperty = levelSizeXProperty;
            _levelSizeYProperty = levelSizeYProperty;
        }

        public void Restrict(ref float x, ref float y)
        {
            x = Math.Clamp(x, 0f, _levelSizeXProperty.Value);
            y = Math.Clamp(y, 0f, _levelSizeYProperty.Value);
        }
    }
}