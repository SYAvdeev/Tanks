using Configs.ViewModel;
using Features;
using UnityEngine;

namespace Services.Factory.ViewModel
{
    public class FeatureViewRoot : MonoBehaviour
    {
        [SerializeField]
        private ViewFacadeDictionary _viewFacadeDictionary;

        public ViewFacadeDictionary ViewFacadeDictionary => _viewFacadeDictionary;

        public TViewFacade GetViewFacade<TViewFacade>(ViewType viewType) where TViewFacade : BaseViewFacade
            => (TViewFacade)_viewFacadeDictionary[viewType];
    }
}