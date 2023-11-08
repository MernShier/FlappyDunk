using System;
using System.Collections.Generic;
using Core.StateMachine.States;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states = new();
        private IState _currentState;
        
        public GameStateMachine(PlayState playState, LevelStartState levelStartState)
        {
            _states.Add(typeof(PlayState), playState);
            _states.Add(typeof(LevelStartState), levelStartState);
        }

        public void SwitchState(Type newState)
        {
            if (!_states.ContainsKey(newState)) return;
            
            _currentState?.Exit();
            _currentState = _states[newState];
            _currentState.Enter();
        }
    }
}
