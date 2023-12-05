using Configs.Prototype;
using UnityEngine;

namespace Configs
{
    public class AddressablesPrototypesConfig : ScriptableObject
    {
        [SerializeField]
        private PrototypeDictionary _prototypeDictionary;

        public PrototypeDictionary PrototypeDictionary => _prototypeDictionary;
    }
}