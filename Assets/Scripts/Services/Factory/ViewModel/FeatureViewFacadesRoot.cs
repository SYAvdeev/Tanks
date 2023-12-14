using Configs.ViewModel;
using UnityEngine;

namespace Services.Factory.ViewModel
{
    public class FeatureViewFacadesRoot : MonoBehaviour
    {
        [SerializeField]
        private ViewFacadeDictionary _viewFacadeDictionary;

        public ViewFacadeDictionary ViewFacadeDictionary => _viewFacadeDictionary;
    }
}