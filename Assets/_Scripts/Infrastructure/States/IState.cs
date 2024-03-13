namespace _Scripts.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IPayLoadedState<in TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
    
    public interface IExitableState
    {
        void Exit();
    }
}