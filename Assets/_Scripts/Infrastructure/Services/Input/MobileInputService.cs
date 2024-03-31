﻿using UnityEngine;

namespace _Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(SimpleInput.GetAxisRaw(Horizontal), SimpleInput.GetAxisRaw(Vertical));
                return axis;
            }
        }

        public override bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(AttackButton);
        }
    }
}