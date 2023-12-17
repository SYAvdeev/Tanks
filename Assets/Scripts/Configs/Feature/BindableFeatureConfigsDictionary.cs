using System;
using Common;
using Services.Factory.Features;
using UnityEngine;

namespace Configs.Feature
{
    [Serializable]
    public class BindableFeatureConfig
    {
        [SerializeField]
        private string _featureID;
        [SerializeField]
        private BindableFeatureType _bindableFeatureType;

        public string FeatureID => _featureID;
        public BindableFeatureType BindableFeatureType => _bindableFeatureType;
    }
}