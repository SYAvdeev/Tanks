using System;
using Common;
using Data.Models;
using Domain.Models;

namespace Configs.Model
{
    [Serializable]
    public class ModelListDataDictionary : UnitySerializedDictionary<ModelListName, ModelListData>
    {
        
    }
}