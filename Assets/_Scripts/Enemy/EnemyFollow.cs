using _Scripts.Infrastructure.Factory;
using _Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyFollow : MonoBehaviour
    {
        private const float MinimalDistance = 1f;
        
        private Transform _heroTransform;
        private IGameFactory _gameFactory;
        
        public float MoveSpeed;
        public Vector2 MovementVector;

        public void Construct(Transform heroTransform)
        {
            _heroTransform = heroTransform;
        }

        private void Update()
        {
            MovementVector = Vector2.zero;
            if (_heroTransform && Vector3.Distance(transform.position, _heroTransform.position) >= MinimalDistance)
            {
                MovementVector = (_heroTransform.transform.position - transform.position).normalized;
                transform.position =
                    Vector2.MoveTowards(transform.position, _heroTransform.position, MoveSpeed * Time.deltaTime);
            }
        }
    }
}