using UnityEngine;

namespace _Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string AttackButton = "AttackButton";
        
        public abstract Vector2 Axis { get; }

        public abstract bool IsAttackButtonUp();
    }
}