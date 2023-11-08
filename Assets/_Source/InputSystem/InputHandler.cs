using BallSystem;
using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private Ball _ball;
        private bool _started;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, Ball ball)
        {
            _gameStateMachine = gameStateMachine;
            _ball = ball;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Mouse0) &&
                (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Began)) return;

            if (!_started)
            {
                _gameStateMachine.SwitchState(typeof(PlayState));
                _started = true;
            }

            _ball.MoveUp();
        }
    }
}