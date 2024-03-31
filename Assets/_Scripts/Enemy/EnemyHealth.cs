using System;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int _current;

        [SerializeField] 
        private int _max;

        public event Action HealthChanged;

        public int Current
        {
            get => _current;
            set => _current = value;
        }

        public int Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(int damage)
        {
            if (Current <= 0)
            {
                return;
            }
            _current -= damage;
            
            HealthChanged?.Invoke();
        }
    }
}