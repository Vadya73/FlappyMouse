using UnityEngine;
using TMPro;

namespace Scripts.Hero
{
    public class HeroStatsHolder : MonoBehaviour
    {
        [SerializeField] private int _score;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Start()
        {
            ResetStats();
        }

        public void AddScore()
        {
            _score++;
            _scoreText.text = _score.ToString();
        }

        public void ResetStats()
        {
            _score = 0;
        }
    }
}