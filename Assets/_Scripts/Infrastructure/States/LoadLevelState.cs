using _Scripts.Infrastructure.Factory;
using UnityEngine;

namespace _Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero();
            Debug.Log("Create hero");
            _gameFactory.CreateHud();
            
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}