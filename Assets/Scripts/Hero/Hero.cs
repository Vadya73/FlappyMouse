using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Hero
{
    [RequireComponent(typeof(HeroMovement), typeof(HeroStatsHolder))]
    public class Hero : MonoBehaviour
    {
        private HeroMovement _heroMovement;
        private HeroStatsHolder _heroStatsHolder;

        public static Action OnGameOvered;
        
        private void Awake()
        {
            _heroMovement = GetComponent<HeroMovement>();
            _heroStatsHolder = GetComponent<HeroStatsHolder>();
        }

        private void Start() => ResetPlayer();
        
        
        public void Death()
        {
            OnGameOvered.Invoke();
        }

        public void ResetPlayer()
        {
            _heroMovement.ResetHero();
            _heroStatsHolder.ResetStats();
        }
    }
}