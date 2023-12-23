using System;
using Domain.Logic.Transformable;
using ReactiveTypes;

namespace Domain.Logic.Camera
{
    public class CameraCharacterMoveRestrictionLogic : IMoveRestrictionLogic
    {
        private readonly IReactivePropertyReadonly<float> _cameraSizeXProperty;
        private readonly IReactivePropertyReadonly<float> _cameraSizeYProperty;
        private readonly IReactivePropertyReadonly<float> _levelSizeXProperty;
        private readonly IReactivePropertyReadonly<float> _levelSizeYProperty;

        public CameraCharacterMoveRestrictionLogic(
            IReactivePropertyReadonly<float> cameraSizeXProperty, 
            IReactivePropertyReadonly<float> cameraSizeYProperty, 
            IReactivePropertyReadonly<float> levelSizeXProperty, 
            IReactivePropertyReadonly<float> levelSizeYProperty)
        {
            _cameraSizeXProperty = cameraSizeXProperty;
            _cameraSizeYProperty = cameraSizeYProperty;
            _levelSizeXProperty = levelSizeXProperty;
            _levelSizeYProperty = levelSizeYProperty;
        }

        public void Restrict(ref float x, ref float y)
        {
            x = Math.Clamp(x, _cameraSizeXProperty.Value / 2f, _levelSizeXProperty.Value - (_cameraSizeXProperty.Value / 2f));
            y = Math.Clamp(y, _cameraSizeYProperty.Value / 2f, _levelSizeYProperty.Value - (_cameraSizeYProperty.Value / 2f));
        }
    }
}