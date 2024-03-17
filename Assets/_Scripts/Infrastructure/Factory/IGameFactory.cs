using System.Collections.Generic;
using _Scripts.Infrastructure.Services;
using _Scripts.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero();
        GameObject CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        void Cleanup();
    }
}