using _Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero();
        GameObject CreateHud();
    }
}