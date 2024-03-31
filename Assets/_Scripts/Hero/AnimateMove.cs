using System;
using UnityEngine;

namespace _Scripts.Hero
{
    [RequireComponent(typeof(HeroMove))]
    [RequireComponent(typeof(HeroAnimator))]
    public class AnimateMove : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        private HeroMove _heroMove;
        private HeroAnimator _animator;

        private void Awake()
        {
            _heroMove = GetComponent<HeroMove>();
            _animator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            if (_heroMove.MovementVector.magnitude > MinimalVelocity)
            {
                _animator.Move(_heroMove.MovementVector);
            }
            else
            {
                _animator.StopMoving();
            }
        }
    }
}