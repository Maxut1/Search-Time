using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SortItems
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private ItemType[] itemTypes; // Массив типов предметов
        [SerializeField] private ItemSpawner itemSpawner; // Ссылка на ваш ItemSpawner
        [SerializeField] private Text taskText; // UI элемент для отображения задания

        private ItemType currentItemType;

        private void Start()
        {
            SetNewTask(); // Запуск задания при старте
        }

        // Метод для установки нового задания
        public void SetNewTask()
        {
            // Выбираем случайный тип предмета
            currentItemType = itemTypes[Random.Range(0, itemTypes.Length)];
            
            // Выводим задание в консоль и UI
            string taskDescription = "Соберите 5 " + currentItemType.ToString();
            Debug.Log(taskDescription); // Выводим текст задания в консоль
            taskText.text = taskDescription; // Обновляем текст на UI

            // Спавним 5 предметов этого типа
            string currentTag = currentItemType.ToString(); // Преобразуем тип в строку для тега
            itemSpawner.SpawnItems(currentItemType, 5);
        }
    }
}