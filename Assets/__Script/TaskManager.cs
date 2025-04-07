using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SortItems
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private ItemType[] itemTypes; // Массив типов предметов
        [SerializeField] private ItemsSpawn itemsSpawn; // Ссылка на ваш ItemsSpawn
        [SerializeField] private Text taskText; // UI элемент для отображения задания

        private ItemType currentItemType;

        private void Start()
        {
            SetNewTask();
        }

        public void SetNewTask()
        {
            // Выбираем случайный тип предмета
            currentItemType = itemTypes[Random.Range(0, itemTypes.Length)];
            taskText.text = "Соберите 5 " + currentItemType.ToString(); // Обновляем текст задания

            // Спавним 5 предметов этого типа
            itemsSpawn.SpawnItems(currentItemType, 5);
        }
    }
}