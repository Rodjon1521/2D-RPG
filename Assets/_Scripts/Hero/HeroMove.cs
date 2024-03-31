using _Scripts.Data;
using _Scripts.Infrastructure.Services;
using _Scripts.Infrastructure.Services.PersistentProgress;
using _Scripts.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        private Rigidbody2D _rigidbody;
        public float MovementSpeed = 10f;
        public Vector2 MovementVector;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MovementVector = Vector2.zero;

            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                MovementVector = _inputService.Axis.normalized;
            }
            
            _rigidbody.MovePosition(_rigidbody.position + MovementVector * (MovementSpeed * Time.fixedDeltaTime));
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (SceneManager.GetActiveScene().name == progress.WorldData.PositionOnLevel.Level)
            {
                var savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null)
                {
                    Warp(savedPosition);
                }
            }
        }

        private void Warp(Vector3Data to)
        {
            transform.position = to.AsUnityVector();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new PositionOnLevel(SceneManager.GetActiveScene().name,  transform.position.AsVectorData());
        }
    }
}