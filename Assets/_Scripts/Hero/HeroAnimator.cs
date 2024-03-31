using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        private Animator _animator;
        public GameObject body;
        public List<SpriteRenderer> _sprites;
        
        public GameObject weaponRoot;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();

            foreach (var sr in body.GetComponentsInChildren<SpriteRenderer>())
            {
                _sprites.Add(sr);
            }
        }

        public void Move(Vector2 dir)
        {
            _animator.SetBool(IsMoving, true);
            AdjustDirection(dir);
        }

        private void AdjustDirection(Vector2 dir)
        {
            foreach (var sr in _sprites)
            {
                sr.flipX = dir.x >= 0;
            }
            
            weaponRoot.transform.rotation = Quaternion.Euler(0, dir.x < 0 ? 0 : 180, 40);
        }

        public void StopMoving()
        {
            _animator.SetBool(IsMoving, false);
        }
    }
}