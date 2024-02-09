using _Scripts.Services.Input;
using UnityEngine;

namespace _Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            if (Application.isEditor)
            {
                InputService = new StandaloneInputService();
            }
            else
            {
                InputService = new MobileInputService();
            }
        }
    }
}