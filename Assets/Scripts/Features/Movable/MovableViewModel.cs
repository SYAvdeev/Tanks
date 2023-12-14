using Domain.Logic;
using Domain.Models;
using ReactiveTypes;
using UnityEngine;

namespace Features.Movable
{
    public class MovableViewModel : BaseViewModel
    {
        public IReactiveProperty<float> PositionX { get; }
        public IReactiveProperty<float> PositionY { get; }
        public IReactiveProperty<float> AngleDegrees { get; }
        
        public MovableViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            PositionX = model.GetProperty<float>(ModelPropertyName.PositionX);
            PositionY = model.GetProperty<float>(ModelPropertyName.PositionY);
            
            IReactiveProperty<float> angleModelProperty = model.GetProperty<float>(ModelPropertyName.DirectionAngle);
            angleModelProperty.OnValueChanged += AngleModelPropertyOnOnValueChanged;
            AngleDegrees = new ReactiveProperty<float>(-angleModelProperty.Value * Mathf.Rad2Deg);
        }

        private void AngleModelPropertyOnOnValueChanged(float angle)
        {
            AngleDegrees.Value = CalculateAngleDegrees(angle);
        }

        private float CalculateAngleDegrees(float angle) => -angle * Mathf.Rad2Deg;
    }
}