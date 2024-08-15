using UnityEngine;

namespace Tanks.UI
{
    public class UIViewRoot : MonoBehaviour
    {
        [SerializeField] private Transform _uiViewsParent;

        public Transform UIViewsParent => _uiViewsParent;
    }
}