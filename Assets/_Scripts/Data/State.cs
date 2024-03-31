using System;

namespace _Scripts.Data
{
    [Serializable]
    public class State
    {
        public int CurrentHP;
        public int MaxHP;

        public void ResetHP()
        {
            CurrentHP = MaxHP;
        }
    }
}