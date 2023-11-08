namespace Core.StateMachine.States
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}