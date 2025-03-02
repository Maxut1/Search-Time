using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class itemClickVFX : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameObject _circleClickPrefab;

        public UnityEvent OnClick;

        public void OnPointerDown(PointerEventData eventData)
        {
            Instantiate(_circleClickPrefab, transform.position, Quaternion.identity, null);
            OnClick.Invoke();
        }
    }

}

