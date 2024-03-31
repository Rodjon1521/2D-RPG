using System;
using System.Collections.Generic;
using _Scripts.Hero;
using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Infrastructure.Services.PersistentProgress;
using _Scripts.Logic;
using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } =  new List<ISavedProgress>();
        
        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject HeroGameObject { get; set; }
        public event Action HeroCreated;

        public GameObject CreateHero(Vector3 at)
        {
            HeroGameObject = InstantiateRegistered(AssetPath.HeroPath, at);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        public GameObject CreateHud(GameObject hero)
        {
            var hud = InstantiateRegistered(AssetPath.HudPath);
            hud.GetComponent<ActorUI>().Construct(hero.GetComponent<IHealth>());
            return hud;
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