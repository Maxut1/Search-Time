using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] allPrefabs; // Все возможные префабы предметов
        [SerializeField] private Vector3 spawnRange; // Диапазон для спавна предметов

        // Метод для спавна предметов определенного типа
        public void SpawnItems(ItemType itemType, int count)
        {
            // Спавним предметы заданного типа
            int spawnedCount = 0;

            while (spawnedCount < count)
            {
                // Выбираем случайный префаб, который соответствует типу
                GameObject selectedPrefab = null;
                foreach (var prefab in allPrefabs)
                {
                    var dragItem = prefab.GetComponent<DragItem>();
                    if (dragItem != null && dragItem.Type == itemType)
                    {
                        selectedPrefab = prefab;
                        break;
                    }
                }

                if (selectedPrefab != null)
                {
                    // Генерируем случайную позицию
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), 
                                                        Random.Range(0, spawnRange.y), 
                                                        Random.Range(-spawnRange.z, spawnRange.z));
                    
                    Instantiate(selectedPrefab, spawnPosition, Quaternion.identity); // Спавним объект
                    spawnedCount++; // Увеличиваем счетчик спавненных предметов
                }
            }
        }

        // Пример метода GetCurrentTargetType
        public ItemType GetCurrentTargetType()
        {
            // Здесь должна быть логика для определения текущего типа предмета.
            // Например, вы можете хранить текущий тип в переменной класса.
            return ItemType.SomeDefaultType; // Замените на вашу логику
        }
    }
}