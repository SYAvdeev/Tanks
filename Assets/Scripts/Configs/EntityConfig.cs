using Configs.Logic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName ="ModelConfig", menuName = "Assets/Config/Model Config", order = 0)]
    public class EntityConfig : ScriptableObject
    {
        [SerializeField]
        private ModelConfig _modelConfig;

        [SerializeField]
        private LogicConfig[] _logicConfigs;
    }
}