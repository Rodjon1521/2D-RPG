using UnityEngine;

namespace _Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
                return axis;
            }
        }
    }
}