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

        protected new void OnEnable()
        {
            base.OnEnable();
            PlayerScriptableModel.OnLoad.AddListener(UpdateScore);
        }

        protected void OnDisable()
        {
            base.OnDisable();
            PlayerScriptableModel.OnLoad.RemoveListener(UpdateScore);
        }

        public void UpdateScore()
        {
            ScoreText.text = PlayerScriptableModel.Model.Score.ToString();
        }
    }
}


