using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts.Hero
{
    public class HeroStatsHolder : MonoBehaviour
    {
        [SerializeField] private int _score;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Start()
        {
            _score = 0;
        }

        private void Update()
        {
            _scoreText.text = _score.ToString();
        }

        public void AddScore()
        {
            _score++;
            Debug.Log($"{_score}");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Score"))
            {
                AddScore();
            }
        }
    }
}