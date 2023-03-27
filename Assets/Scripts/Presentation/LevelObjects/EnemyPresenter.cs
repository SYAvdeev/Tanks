using Domain.LevelObjects;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public class EnemyPresenter : CharacterPresenter
    {
        private const string PlayerTag = "Player";

        public EnemyModel EnemyModel => (EnemyModel)_levelObjectModel;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(PlayerTag))
            {
                EnemyModel.SetAttack(true);
            }
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                EnemyModel.SetAttack(false);
            }
        }
        
        protected override void Destroy(LevelObjectModel levelObjectModel)
        {
            base.Destroy(levelObjectModel);
            _sceneObjectsSpawner.AddToPool(this);
        }
    }
}