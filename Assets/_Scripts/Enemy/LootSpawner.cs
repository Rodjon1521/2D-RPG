﻿using System;
using _Scripts.Infrastructure.Factory;
using _Scripts.Logic;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        public EnemyDeath EnemyDeath;
        private IGameFactory _factory;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            EnemyDeath.Happened += SpawnLoot;
        }

        private void SpawnLoot()
        {
            GameObject loot = _factory.CreateLoot();
            loot.transform.position = transform.position;
        }
    }
}