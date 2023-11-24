using System.Collections.Generic;
using Data.Config;
using Domain.Models;
using Presentation.LevelObjects;
using UnityEngine;

namespace Presentation
{
    public class SceneObjectsSpawner : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _poolParent;
        [SerializeField] private ConfigScriptableObject configScriptableObject;
        [SerializeField] private GameObject _bulletPresenterPrefab;

        private readonly Dictionary<string, Stack<LevelObjectPresenter>> _enemiesPool = new();
        private readonly Stack<LevelObjectPresenter> _bulletsPool = new();

        public EnemyPresenter SpawnEnemy(EnemyModel enemyModel, Transform parent)
        {
            string enemyName = enemyModel.Config.Name;
            if (!_enemiesPool.ContainsKey(enemyName))
            {
                _enemiesPool[enemyName] = new Stack<LevelObjectPresenter>();
            }
            
            EnemyConfig enemyConfig = configScriptableObject.GetEnemyConfig(enemyName);
            return (EnemyPresenter)SpawnLevelObjectPresenter(enemyModel, _enemiesPool[enemyName], enemyConfig.Prefab, parent);
        }
        
        public BulletPresenter SpawnBullet(DamagerModel damagerModel, Transform parent)
        {
            return (BulletPresenter)SpawnLevelObjectPresenter(damagerModel, _bulletsPool, _bulletPresenterPrefab, parent);
        }

        private LevelObjectPresenter SpawnLevelObjectPresenter<T>(T levelObject, Stack<LevelObjectPresenter> pool,
            GameObject prefab, Transform parent) where T : TransformableModel
        {
            if (!pool.TryPop(out LevelObjectPresenter presenter))
            {
                presenter = Instantiate(prefab, parent).GetComponent<LevelObjectPresenter>();
                presenter.Initialize(this, _camera.orthographicSize);
            }
            else
            {
                presenter.transform.SetParent(parent);
            }
            
            presenter.gameObject.SetActive(true);
            presenter.SetLevelObject(levelObject);
            return presenter;
        }

        public void AddToPool(EnemyPresenter enemyPresenter)
        {
            enemyPresenter.transform.parent = _poolParent;
            _enemiesPool[enemyPresenter.EnemyModel.Config.Name].Push(enemyPresenter);
        }
        
        public void AddToPool(BulletPresenter bulletPresenter)
        {
            bulletPresenter.transform.parent = _poolParent;
            _bulletsPool.Push(bulletPresenter);
        }
    }
}