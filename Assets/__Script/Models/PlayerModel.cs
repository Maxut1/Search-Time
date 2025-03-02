using UnityEngine;

namespace SortItems
{
    
    [System.Serializable]
    public class PlayerModel : Model
    {
        [SerializeField] protected string _playerName;
        [SerializeField] protected int _score;

        public string PlayerName
        {
            get => _playerName;
            set => SetData(ref _playerName, value);
        }

        public int Score
        {
            get => _score;
            set
            {
                if (value < 0)
                {
                    return;
                }

                SetData(ref _score, value);
            }
        }
    }
}

