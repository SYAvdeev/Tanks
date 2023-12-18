using Configs.ViewModel;
using UnityEngine;

namespace Services.Factory.ViewModel
{
    public class FeatureViewRoot : MonoBehaviour
    {
        [SerializeField]
        private ViewFacadeDictionary _viewFacadeDictionary;

        public ViewFacadeDictionary ViewFacadeDictionary => _viewFacadeDictionary;
    }
}