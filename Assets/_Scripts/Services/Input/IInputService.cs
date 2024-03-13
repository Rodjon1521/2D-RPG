using _Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}