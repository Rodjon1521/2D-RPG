using System;
using _Scripts.Hero;
using _Scripts.Infrastructure.Factory;
using _Scripts.Infrastructure.Services;
using _Scripts.Logic;
using _Scripts.Weapon;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public SwordAnimator Animator;
        public TriggerObserver DamageObserver;

        public float AttackCooldown = 3f;
        private float _attackCooldown;
        private bool _isAttacking;
        private bool _attackIsActive;
        private bool _isHit;
        private IHealth _heroHealth;
        public int Damage = 10;

        private void Start()
        {
            DamageObserver.TriggerEnter += TriggerEnter;
            DamageObserver.TriggerExit += TriggerExit;
        }

        private void TriggerExit(Collider2D obj)
        {
            _isHit = false;
        }

        private void TriggerEnter(Collider2D obj)
        {
            _isHit = true;
            _heroHealth = obj.transform.GetComponent<IHealth>();
        }

        private void Update()
        {
            if (_attackCooldown <= 0 && !_isAttacking && _attackIsActive)
            {
                Animator.Attack();
                _isAttacking = true;
            }

            if (_attackCooldown > 0)
            {
                _attackCooldown -= Time.deltaTime;
            }
        }

        private void OnAttack()
        {
            if (_isHit)
            {
                _heroHealth.TakeDamage(Damage);
            }
            
        }

        private void OnAttackEnded()
        {
            _attackCooldown = AttackCooldown;
            _isAttacking = false;
            Animator.ToEmpty();
        }

        public void EnableAttack()
        {
            _attackIsActive = true;
        }

        public void DisableAttack()
        {
            _attackIsActive = false;
        }
    }
}