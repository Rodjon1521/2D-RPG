using System;
using _Scripts.Infrastructure;
using _Scripts.Infrastructure.Services;
using _Scripts.Services.Input;
using UnityEngine;

namespace _Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed = 10f;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _inputService.Axis;
            }
            
            CharacterController.Move(movementVector * (MovementSpeed * Time.deltaTime));
        }
    }
}