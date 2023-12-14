using System;
using Common;
using Features;
using Services.Factory.ViewModel;

namespace Configs.ViewModel
{
    [Serializable]
    public class ViewFacadeDictionary : UnitySerializedDictionary<ViewType, BaseViewFacade>
    {
        
    }
}