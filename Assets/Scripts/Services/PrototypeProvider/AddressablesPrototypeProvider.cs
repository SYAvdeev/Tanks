using System.Collections.Generic;
using Configs.Prototype;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services.PrototypeProvider
{
    public class AddressablesPrototypeProvider : IPrototypeProvider
    {
        private readonly AddressablesPrototypesConfig _config;
        private readonly Dictionary<string, GameObject> _cachedPrototypes;

        public AddressablesPrototypeProvider(AddressablesPrototypesConfig config)
        {
            _config = config;
            _cachedPrototypes = new Dictionary<string, GameObject>();
        }

        public async UniTask<T> Get<T>(string key)
        {
            if (!_config.PrototypeDictionary.ContainsKey(key))
            {
                throw new KeyNotFoundException($"Config doesn't contain key {key}");
            }

            if (!_cachedPrototypes.TryGetValue(key, out GameObject gameObject))
            {
                AssetReferenceConfig prototypeConfig = _config.PrototypeDictionary[key];
                gameObject = await Addressables.LoadAssetAsync<GameObject>(prototypeConfig.AssetReference).ToUniTask();
                _cachedPrototypes[key] = gameObject;
            }

            return gameObject.GetComponent<T>();
        }

        public void Release(string key)
        {
            if (_cachedPrototypes.TryGetValue(key, out GameObject gameObject))
            {
                Addressables.Release(gameObject);
            }
        }
    }
}