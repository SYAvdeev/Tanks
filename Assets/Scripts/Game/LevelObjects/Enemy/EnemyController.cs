using UnityEngine;

namespace Tanks.Enemy
{
    public class EnemyController : IEnemyController
    {
        private readonly IEnemyService _enemyService;
        private readonly EnemyView _enemyView;
        
        public void Initialize()
        {
            _enemyService.Model.MovableModel.PositionUpdated += MovableModelOnPositionUpdated;
            _enemyService.Model.MovableModel.DirectionAngleUpdated += MovableModelOnDirectionAngleUpdated;
        }

        private void MovableModelOnPositionUpdated(Vector2 position)
        {
            
        }

        private void MovableModelOnDirectionAngleUpdated(float directionAngle)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}