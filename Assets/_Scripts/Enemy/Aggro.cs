using System;
using System.Collections;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public EnemyFollow Follow;

        public float Cooldown;
        
        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            Follow.enabled = false;
        }

        private void TriggerEnter(Collider2D obj)
        {
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;
                if (_aggroCoroutine != null)
                {
                    StopCoroutine(_aggroCoroutine);
                    _aggroCoroutine = null;
                }
            
                Follow.enabled = true;
            }

        }

        private void TriggerExit(Collider2D obj)
        {
            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;
                _aggroCoroutine = StartCoroutine(OffFollowAfterCooldown());
            }
        }

        private IEnumerator OffFollowAfterCooldown()
        {
            yield return new WaitForSeconds(Cooldown);
            Follow.enabled = false;
            Follow.MovementVector = Vector2.zero;
        }
    }
}