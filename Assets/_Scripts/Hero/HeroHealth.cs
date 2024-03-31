using System;
using _Scripts.Data;
using _Scripts.Infrastructure.Services.PersistentProgress;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Hero
{
    public class HeroHealth : MonoBehaviour, ISavedProgress, IHealth
    {
        private State _state;

        public event Action HealthChanged;

        public int Current
        {
            get => _state.CurrentHP;
            set
            {
                if (_state.CurrentHP != value)
                {
                    HealthChanged?.Invoke();
                    _state.CurrentHP = value;
                }
            }
        }

        public int Max
        {
            get => _state.MaxHP;
            set => _state.MaxHP = value;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.HeroState;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.CurrentHP = Current;
            progress.HeroState.MaxHP = Max;
        }

        public void TakeDamage(int damage)
        {
            // TODO(rodjon): make crit chance 
            if (Current <= 0)
            {
                return;
            }
            Current -= damage;
        }
    }
}