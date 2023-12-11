using UnityEngine;

namespace Configs.Prototype
{
    public class AddressablesPrototypesConfig : ScriptableObject
    {
        [SerializeField]
        private PrototypeDictionary _prototypeDictionary;

        public PrototypeDictionary PrototypeDictionary => _prototypeDictionary;
    }
}