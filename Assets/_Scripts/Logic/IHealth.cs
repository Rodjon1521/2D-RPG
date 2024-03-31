using System;

namespace _Scripts.Logic
{
    public interface IHealth
    {
        event Action HealthChanged;
        int Current { get; set; }
        int Max { get; set; }
        void TakeDamage(int damage);
    }
}