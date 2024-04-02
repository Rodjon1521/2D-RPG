using System.Collections.Generic;
using _Scripts.Infrastructure.Services;
using _Scripts.Infrastructure.Services.PersistentProgress;
using _Scripts.Logic;
using _Scripts.StaticData;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud(GameObject hero);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        void Cleanup();
        void Register(ISavedProgressReader savedProgressReader);
        GameObject CreateEnemy(EnemyTypeId enemyTypeId, Transform parent);
    }
}