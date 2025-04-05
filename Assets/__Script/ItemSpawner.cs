using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs; // Массив префабов для обычных предметов
        [SerializeField] private GameObject[] _targetPrefabs; // Массив префабов для целевых предметов
        [SerializeField] private Vector3 _spawnRange; // Диапазон спавна

        private ItemType _currentTargetType;

        private void Start()
        {
            SpawnItems();
            SetRandomTargetItem();
        }

        private void SpawnItems()
        {
            int spawnCount = Random.Range(15, 31); 

            for (int i = 0; i < spawnCount; i++)
            {
                int randomIndex = Random.Range(0, _prefabs.Length);
                Vector3 offset = new Vector3(Random.Range(-_spawnRange.x, _spawnRange.x), 
                                              Random.Range(-_spawnRange.y, _spawnRange.y), 
                                              Random.Range(-_spawnRange.z, _spawnRange.z));
                
                Instantiate(_prefabs[randomIndex], transform.position + offset, Quaternion.identity);
            }
        }

private void SetRandomTargetItem()
{
    if (_targetPrefabs.Length == 0)
    {
        Debug.LogError("Массив целевых префабов пуст!");
        return;
    }

    // Случайно выбираем один из целевых префабов
    int targetPrefabIndex = Random.Range(0, _targetPrefabs.Length);
    
    // Используем Raycast для определения позиции спавна
    RaycastHit hit;
    if (Physics.Raycast(new Vector3(0.72f, 10f, -14.53f), Vector3.down, out hit))
    {
        Vector3 spawnPosition = hit.point + new Vector3(0, 1f, 0); // Спавн выше поверхности
        
        GameObject targetItemInstance = Instantiate(_targetPrefabs[targetPrefabIndex], spawnPosition, Quaternion.identity);
        
        // Получаем тип текущего целевого предмета
        _currentTargetType = targetItemInstance.GetComponent<DragItem>().Type;

        targetItemInstance.name = "Target Item: " + _currentTargetType.ToString(); // Установите имя для удобства
        
        Debug.Log("Спавн целевого предмета: " + targetItemInstance.name + " на позиции: " + spawnPosition);
    }
}

        public ItemType GetCurrentTargetType()
        {
            return _currentTargetType;
        }
    }
}