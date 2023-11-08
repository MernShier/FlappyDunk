using System;
using BallSystem;
using UnityEngine;
using Zenject;


namespace Core.StateMachine.States
{
    public class LevelStartState : IState
    {
        private readonly Ball _ball;

        private LevelStartState(Ball ball)
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