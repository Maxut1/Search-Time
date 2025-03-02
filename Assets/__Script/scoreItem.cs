using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SortItems
{
    public class scoreItem : MonoBehaviour
    {
        
        [SerializeField] private Text Caunter;
        public int ScoreCaunt = 0;
        public int CurentScore;

        private void Start()
        {
            Caunter = GetComponent<Text>();
            CurentScore = ScoreCaunt;
        }

        private void Update()
        {
            
            if (CurentScore != ScoreCaunt)
            {
                ScoreCaunt = CurentScore;
                Caunter.text = ScoreCaunt.ToString() + "/5";
        
            }
        }

        public void AddScore()
        {
            CurentScore++;
        }
        
        
    }
}


