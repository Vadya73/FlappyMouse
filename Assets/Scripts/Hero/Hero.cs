using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Hero
{
    [RequireComponent(typeof(HeroMovement), typeof(HeroStatsHolder))]
    public class Hero : MonoBehaviour
    {
        private HeroMovement _heroMovement;
        private HeroStatsHolder _heroStatsHolder;

        public event UnityAction GameOver;

        private void Start()
        {
            _heroMovement = GetComponent<HeroMovement>();
            _heroStatsHolder = GetComponent<HeroStatsHolder>();

            ResetPlayer();
        }
        public void Death()
        {
            Debug.Log("Умер!");
            GameOver?.Invoke();
        }

        public void ResetPlayer()
        {
            _heroMovement.ResetHero();
            _heroStatsHolder.ResetStats();
        }
    }
}