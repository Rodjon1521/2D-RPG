using System;
using System.Collections;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Logic
{
    class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth Health;
        
        public event Action Happened;

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (Health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            StartCoroutine(DestroyTimer());
            Happened?.Invoke();
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}