using System;
using _Scripts.Data;
using _Scripts.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace _Scripts.Logic
{
    public class EnemySpawner : MonoBehaviour, ISavedProgress
    {
        private string _id;

        public bool Slain;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearedSpawners.Contains(_id))
            {
                Slain = true;
            }
            else
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (Slain)
            {
                progress.KillData.ClearedSpawners.Add(_id);
            }
        }
    }
}