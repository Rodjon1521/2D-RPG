using _Scripts.Infrastructure.AssetManagement;
using UnityEditor.iOS;
using UnityEngine;

namespace _Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        
        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero()
        {
            return _assets.Instantiate(AssetPath.HeroPath);
        }

        public GameObject CreateHud()
        {
            return _assets.Instantiate(AssetPath.HudPath);
        }
    }
}