
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace SortItems
{
    public class Getter : MonoBehaviour
    {
        [SerializeField] private ItemType type;
        private DragItem _item;
        private Material _Material;
        private Color _defaulColor;


        private int targetCount = 1;
        private int count = 0;
        private bool active = true;

        public UnityEvent<Getter> onCountChanget;

        public void SetCount(int value)
        {
            targetCount = value;

            if (count >= targetCount)
            {
                _Material.color = Color.gray;
                active = false;
            }
        }


        private void Start() 
        {
            _Material = GetComponent<MeshRenderer>().material;
            _defaulColor = _Material.color;
        }

        private void OnTriggerStay(Collider other)
        {
            if(!active)
                return;

            var item = other.attachedRigidbody.GetComponent<DragItem>();

            if (item != null && item.isDraggable == true) 
            {
                _item = item;

                if(_item.Type == type)
                {
                    _Material.color = Color.green;
                }
                else
                {
                    _Material.color = Color.red;
                }

                return;
            }

            if (item.isDraggable == false && _item == item)
            {
                TryGetItem();
                _item = null;
                _Material.color = _defaulColor;
                return;
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if(!active)
                return;

            var item = other.attachedRigidbody.GetComponent<DragItem>();
            if (_item == item)
            {
               _Material.color = _defaulColor;
               
                if (item.isDraggable == false)
                {
                    TryGetItem();
                }
                _item = null;

            }
        }

        private void TryGetItem()
        {
            if(_item.Type == type)
            {
                //Destroy(_item.gameObject);
                count++;

                if (count >= targetCount)
                {
                    _Material.color = Color.gray;
                    active = false;
                }
                onCountChanget.Invoke(this);
                
                _item.OnHideRequest.Invoke();

            }
        }
        

    }

        public enum ItemType
        {
            CubeLego,

            miniLego,

            LongLego,
            
            surprise,
            
            Lego
        }

}


