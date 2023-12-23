using UnityEngine;

namespace Configs.Prototype
{
    [CreateAssetMenu(fileName ="AddressablesPrototypesConfig", menuName = "Assets/Config/Addressables Prototypes Config", order = 0)]
    public class AddressablesPrototypesConfig : ScriptableObject
    {
        [SerializeField]
        private PrototypeDictionary _prototypeDictionary;

        public PrototypeDictionary PrototypeDictionary => _prototypeDictionary;
    }
}