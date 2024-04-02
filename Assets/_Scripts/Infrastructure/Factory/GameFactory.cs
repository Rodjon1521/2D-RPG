using System.Collections.Generic;
using _Scripts.Enemy;
using _Scripts.Hero;
using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Infrastructure.Services;
using _Scripts.Infrastructure.Services.PersistentProgress;
using _Scripts.Logic;
using _Scripts.StaticData;
using _Scripts.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } =  new List<ISavedProgress>();
        
        public GameFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        private GameObject HeroGameObject { get; set; }

        public GameObject CreateHero(Vector3 at)
        {
            HeroGameObject = InstantiateRegistered(AssetPath.HeroPath, at);
            return HeroGameObject;
        }

        public GameObject CreateHud(GameObject hero)
        {
            var hud = InstantiateRegistered(AssetPath.HudPath);
            hud.GetComponent<ActorUI>().Construct(hero.GetComponent<IHealth>());
            return hud;
        }

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId, Transform parent)
        {
            var enemyData = _staticData.ForEnemy(enemyTypeId);
            GameObject enemy = Object.Instantiate(enemyData.Prefab, parent.position, Quaternion.identity, parent);
            
            var health = enemy.GetComponent<IHealth>();
            health.Current = enemyData.Hp;
            health.Max = enemyData.Hp;
            
            enemy.GetComponent<ActorUI>().Construct(health);
            var movement = enemy.GetComponent<EnemyFollow>();
            movement.Construct(HeroGameObject.transform);
            movement.MoveSpeed = enemyData.MoveSpeed;

            var lootSpawner = enemy.GetComponentInChildren<LootSpawner>();
            lootSpawner.Construct(this);

            return enemy;
        }

        public GameObject CreateLoot()
        {
            return InstantiateRegistered(AssetPath.Loot);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressesWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        public void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressesWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }
    }
}