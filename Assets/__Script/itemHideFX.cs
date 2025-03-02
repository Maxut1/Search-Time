using UnityEngine;
using System;


namespace SortItems
{
    public class itemHideFX : MonoBehaviour
    {
        [SerializeField] private VFXPoolProvider _vfxPoolProvider;

        public void Hide()
        {
            VFXPoolItem PoolItem = _vfxPoolProvider.VFXPool.GetFromPool();
            PoolItem.transform.position = transform.position;
            PoolItem.ParticleSystem.Play();

            Destroy(this.gameObject);
        }

    }
}


