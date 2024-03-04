namespace _Scripts.Infrastructure
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