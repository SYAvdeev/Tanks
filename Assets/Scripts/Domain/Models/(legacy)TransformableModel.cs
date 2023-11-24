// using ReactiveTypes;
//
// namespace Domain.Models
// {
//     public class TransformableModel : IModel
//     {
//         public IReactiveProperty<float> PositionX { get; }
//         public IReactiveProperty<float> PositionY { get; }
//         public IReactiveProperty<float> DirectionAngle { get; }
//
//         public TransformableModel(float positionX, float positionY, float directionAngle)
//         {
//             PositionX = new ReactiveProperty<float>(positionX);
//             PositionY = new ReactiveProperty<float>(positionY);
//             DirectionAngle = new ReactiveProperty<float>(directionAngle);
//         }
//
//         public void SetPosition(float positionX, float positionY)
//         {
//             PositionX.Value = positionX;
//             PositionY.Value = positionY;
//         }
//     }
// }