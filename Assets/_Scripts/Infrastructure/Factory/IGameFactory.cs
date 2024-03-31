using System;
using System.Collections.Generic;
using _Scripts.Infrastructure.Services;
using _Scripts.Infrastructure.Services.PersistentProgress;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject HeroGameObject { get; }
        event Action HeroCreated;
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud(GameObject hero);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        void Cleanup();
        void Register(ISavedProgressReader savedProgressReader);
    }
}