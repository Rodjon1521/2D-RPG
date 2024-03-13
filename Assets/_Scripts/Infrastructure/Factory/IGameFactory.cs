using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHero();
        GameObject CreateHud();
    }
}