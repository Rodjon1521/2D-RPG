using System;
using _Scripts.Enemy;
using _Scripts.Infrastructure.Services;
using _Scripts.Logic;
using _Scripts.Services.Input;
using _Scripts.Weapon;
using UnityEngine;

namespace _Scripts.Hero
{
    public class HeroAttack : MonoBehaviour
    {
        public SwordAnimator Animator;
        private IInputService _input;
        
        public TriggerObserver DamageObserver;
        public float AttackCooldown = 3f;
        private float _attackCooldown;
        private IHealth _health;
        public int Damage = 10;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();
        }
        
        private void Start()
        {
            DamageObserver.TriggerEnter += TriggerEnter;
            DamageObserver.TriggerExit += TriggerExit;
        }

        private void TriggerExit(Collider2D obj)
        {
            _health = null;
        }

        private void TriggerEnter(Collider2D obj)
        {
            _health = obj.transform.GetComponent<IHealth>();
        }

        private void Update()
        {
            if (_input.IsAttackButtonUp())
            {
                Animator.Attack();
                _health?.TakeDamage(Damage);
            }
        }
    }
}