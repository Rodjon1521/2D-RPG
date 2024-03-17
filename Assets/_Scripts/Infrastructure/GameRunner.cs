using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper bootstrapperPrefab;
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();

            if (!bootstrapper)
            {
                Instantiate(bootstrapperPrefab);
            }
        }
    }
}