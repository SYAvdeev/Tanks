using Domain.LevelObjects;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public class BulletPresenter : LevelObjectPresenter<BulletModel>
    {
        private const string EnemyTag = "Enemy";
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(EnemyTag))
            {
                CharacterPresenter characterPresenter = collision.gameObject.GetComponent<CharacterPresenter>();
                LevelObjectModel.OnCharacterHit(characterPresenter.LevelObjectModel);
            }
        }

        protected override void Destroy(LevelObjectModel levelObjectModel)
        {
            base.Destroy(levelObjectModel);
            _sceneObjectsSpawner.AddToPool(this);
        }
    }
}