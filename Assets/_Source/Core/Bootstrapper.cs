using System;
using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void Start()
        {
            _gameStateMachine.SwitchState(typeof(LevelStartState));
        }
    }
}