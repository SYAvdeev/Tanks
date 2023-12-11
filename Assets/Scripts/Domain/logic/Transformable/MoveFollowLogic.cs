using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class MoveFollowLogic : TickableLogic, IMoveLogic
    {
        private readonly IReactiveProperty<float> _positionXProperty;
        private readonly IReactiveProperty<float> _positionYProperty;
        private readonly IReactiveProperty<float> _followingPositionXProperty;
        private readonly IReactiveProperty<float> _followingPositionYProperty;

        private readonly IMoveRestrictionLogic _moveRestrictionLogic;

        public MoveFollowLogic(
            ITickService tickService, 
            IReactiveProperty<float> positionXProperty, 
            IReactiveProperty<float> positionYProperty,
            IReactiveProperty<float> followingPositionXProperty, 
            IReactiveProperty<float> followingPositionYProperty,
            IMoveRestrictionLogic moveRestrictionLogic) : base(tickService)
        {
            _positionXProperty = positionXProperty;
            _positionYProperty = positionYProperty;
            _followingPositionXProperty = followingPositionXProperty;
            _followingPositionYProperty = followingPositionYProperty;
            _moveRestrictionLogic = moveRestrictionLogic;
        }

        public override void Tick(float deltaTime)
        {
            float x = _followingPositionXProperty.Value;
            float y = _followingPositionYProperty.Value;

            _moveRestrictionLogic?.Restrict(ref x, ref y);

            _positionXProperty.Value = x;
            _positionYProperty.Value = y;
        }
    }
}