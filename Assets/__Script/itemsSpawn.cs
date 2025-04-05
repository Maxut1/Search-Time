using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class ItemsSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs; // Массив префабов
        [SerializeField] private Vector3 _range; // Диапазон спавна

        public void SpawnItems(ItemType itemType, int count)
        {
            for (int i = 0; i < count; i++)
            {
                // Находим префаб по типу предмета
                GameObject prefabToSpawn = GetPrefabByType(itemType);
                if (prefabToSpawn != null)
                {
                    Vector3 offset = new Vector3(Random.Range(-_range.x, _range.x), 
                                                  Random.Range(-_range.y, _range.y), 
                                                  Random.Range(-_range.z, _range.z));
                    Instantiate(prefabToSpawn, transform.position + offset, Quaternion.identity, transform);
                }
            }
        }

        private GameObject GetPrefabByType(ItemType type)
        {
            foreach (var prefab in _prefabs)
            {
                DragItem dragItem = prefab.GetComponent<DragItem>();
                if (dragItem != null && dragItem.Type == type)
                {
                    return prefab;
                }
            }
            return null; // Если не найдено
        }
    }
}