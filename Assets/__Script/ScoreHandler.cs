using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private Getter[] _getters; // Ссылка на объекты Getter
        [SerializeField] private GameObject ObjectDiactiv;
        [SerializeField] private GameObject ObjectActive;

        public UnityEvent onFull;

        private void Start()
        {
            if (_getters == null || _getters.Length == 0)
            {
                return;
            }

            foreach (var getter in _getters)
            {
                getter.SetCount(getter.GetTargetCount());  // Используем GetTargetCount вместо direct доступа
                getter.onCountChanget.AddListener(OnCountChanget);
            }
        }

        private void OnDestroy()
        {
            foreach (var getter in _getters)
            {
                getter.onCountChanget.RemoveListener(OnCountChanget);
            }
        }

        private void OnCountChanget(Getter getter)
        {
            bool full = true;

            foreach (var item in _getters)
            {
                if (item.GetCount() < item.GetTargetCount()) // Используем GetCount
                {
                    full = false;
                    break;
                }
            }

            if (full)
            {
                ObjectDiactiv.SetActive(false);
                ObjectActive.SetActive(true);
                onFull.Invoke();
            }
        }
    }
}
