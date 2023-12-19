using UnityEngine;

namespace Features.Spawn
{
    public class SpawnViewFacade : BaseViewFacade
    {
        [SerializeField]
        private Transform _spawnParent;

        public Transform SpawnParent => _spawnParent;
    }
}