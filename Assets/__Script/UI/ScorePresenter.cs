using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SortItems
{
    public class ScorePresenter : PlayerScriptableModelProvider
    {
        [SerializeField] protected TMP_Text _scoreText ;

        public TMP_Text ScoreText => _scoreText;

        // Используем 'new' для явного скрытия метода OnEnable из родительского класса
        protected new void OnEnable()
        {
            base.OnEnable();
            PlayerScriptableModel.OnLoad.AddListener(UpdateScore);
        }

        // Используем 'new' для явного скрытия метода OnDisable из родительского класса
        protected new void OnDisable()
        {
            base.OnDisable();
            PlayerScriptableModel.OnLoad.RemoveListener(UpdateScore);
        }

        public void UpdateScore()
        {
            ScoreText.text = PlayerScriptableModel.Model.Score.ToString(); // Обновляем текст на экране
        }
    }
}
