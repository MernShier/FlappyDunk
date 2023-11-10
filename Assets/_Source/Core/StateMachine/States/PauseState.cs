using BallSystem;

namespace Core.StateMachine.States
{
    public class PauseState : IState
    {
        private readonly Ball _ball;

        private PauseState(Ball ball)
        {
            _ball = ball;
        }
        
        public void Enter()
        {
            _ball.Freeze(true);
        }

        public void Exit()
        {
            _ball.Freeze(false);
        }
    }
}