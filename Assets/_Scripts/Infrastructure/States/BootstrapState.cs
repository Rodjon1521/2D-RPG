﻿using _Scripts.Infrastructure.AssetManagement;
using _Scripts.Infrastructure.Factory;
using _Scripts.Infrastructure.Services;
using _Scripts.Services.Input;
using UnityEngine;

namespace _Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }
        
        public void Exit()
        {
            
        }
        
        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("Main");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
        }

        private IInputService InputService()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else
            {
                 return new MobileInputService();
            }
        }
    }
}