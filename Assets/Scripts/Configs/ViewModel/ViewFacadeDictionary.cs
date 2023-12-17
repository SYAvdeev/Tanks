using System;
using Common;
using Features;
using Services.Factory.View;

namespace Configs.ViewModel
{
    [Serializable]
    public class ViewFacadeDictionary : UnitySerializedDictionary<ViewType, BaseViewFacade>
    {
        
    }
}