using System;
using Domain.Features;
using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Destroyable
{
    public class DestroyableFeatureOutOfLevelBoundsLogic : TickableLogic, IDestroyableFeatureOutOfLevelBoundsLogic
    {
        private readonly IReactivePropertyReadonly<float> _levelSizeXProperty;
        private readonly IReactivePropertyReadonly<float> _levelSizeYProperty;
        private readonly IReactivePropertyReadonly<float> _positionXProperty;
        private readonly IReactivePropertyReadonly<float> _positionYProperty;
        private readonly IFeatureBase _featureBase;

        public event Action<IFeatureBase> Destroyed;
        
        public DestroyableFeatureOutOfLevelBoundsLogic(
            IReactivePropertyReadonly<float> levelSizeXProperty,
            IReactivePropertyReadonly<float> levelSizeYProperty,
            IReactivePropertyReadonly<float> positionXProperty,
            IReactivePropertyReadonly<float> positionYProperty,
            IFeatureBase featureBase,
            ITickService tickService) :
            base(tickService)
        {
            _levelSizeXProperty = levelSizeXProperty;
            _levelSizeYProperty = levelSizeYProperty;
            _positionXProperty = positionXProperty;
            _positionYProperty = positionYProperty;
            _featureBase = featureBase;
        }

        public override void Tick(float deltaTime)
        {
            if (_positionXProperty.Value < 0f || _positionXProperty.Value > _levelSizeXProperty.Value ||
                _positionYProperty.Value < 0f || _positionYProperty.Value > _levelSizeYProperty.Value)
            {
                Destroy();
            }
        }
        
        public void Destroy()
        {
            Destroyed?.Invoke(_featureBase);
        }
    }
}