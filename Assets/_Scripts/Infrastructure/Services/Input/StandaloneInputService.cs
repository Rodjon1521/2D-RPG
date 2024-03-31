using UnityEngine;

namespace _Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(SimpleInput.GetAxisRaw(Horizontal), SimpleInput.GetAxisRaw(Vertical));

                if (axis == Vector2.zero)
                {
                    axis = new Vector2(UnityEngine.Input.GetAxisRaw(Horizontal), UnityEngine.Input.GetAxisRaw(Vertical));
                }

                return axis;
            }
        }

        public override bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(AttackButton);
        }
    }
}