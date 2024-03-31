using System;
using UnityEngine;

namespace _Scripts.Enemy
{
    [RequireComponent(typeof(EnemyFollow))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateEnemyMove : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        private EnemyFollow _follow;
        private EnemyAnimator _animator;

        private void Awake()
        {
            _follow = GetComponent<EnemyFollow>();
            _animator = GetComponent<EnemyAnimator>();
        }

        private void Update()
        {
            if (_follow.MovementVector.magnitude > MinimalVelocity)
            {
                _animator.Move(_follow.MovementVector);
            }
            else
            {
                _animator.StopMoving();
            }
        }
    }
}