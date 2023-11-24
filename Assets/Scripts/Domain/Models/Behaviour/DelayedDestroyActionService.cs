// using Domain.Services;
//
// namespace Domain.Models.Behaviour
// {
//     public class DelayedDestroyActionService : DelayedActionService
//     {
//         private readonly TransformableModel _target;
//         
//         public DelayedDestroyActionService(float delay, TransformableModel target) : base(delay)
//         {
//             _target = target;
//         }
//
//         protected override void Action()
//         {
//             //_target.Destroy();
//         }
//     }
// }