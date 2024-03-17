using System.Collections.Generic;
using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Infrastructure.Services.PersistentProgress;
using Unity.VisualScripting;
using UnityEditor.iOS;
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

        public GameObject CreateHero()
        {
            return InstantiateRegistered(AssetPath.HeroPath);
        }

        public GameObject CreateHud()
        {
            return InstantiateRegistered(AssetPath.HudPath);
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

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressesWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }
    }
}