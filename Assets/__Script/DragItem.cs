using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private float upForce = 1000f;
        [SerializeField] private ItemType _type; // Это нужно, чтобы работать с типами предметов
        public UnityEvent OnHideRequest;
        private Rigidbody _rigidbody;
        public bool isDraggable { get; private set; } // Управляем свойством isDraggable напрямую

        // Удалено первое определение Type
        public ItemType Type { get => _type; } // Оставлено только это определение

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!isDraggable)
                return;

            if (!eventData.pointerCurrentRaycast.isValid)
            {
                _rigidbody.isKinematic = false;
                isDraggable = false;
                return;
            }

            var pos = eventData.pointerCurrentRaycast.worldPosition;
            var delta = pos - transform.position;
            delta.y = 0;

            transform.position += delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            isDraggable = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!isDraggable)
                return;

            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * upForce);
            isDraggable = false;
        }
    }
}