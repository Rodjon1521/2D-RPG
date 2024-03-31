using System;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Weapon
{
    public class SwordAnimator : MonoBehaviour
    {
        private static readonly int AttackTrigger = Animator.StringToHash("IsAttack");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Attack()
        {
            _animator.SetBool(AttackTrigger, true);
        }

        public void ToEmpty()
        {
            _animator.SetBool(AttackTrigger, false);
        }
    }
}