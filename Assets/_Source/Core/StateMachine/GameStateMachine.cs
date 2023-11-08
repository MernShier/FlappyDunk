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

        public void SwitchState<T>()
        {
            var type = typeof(T);
            if (!_states.ContainsKey(type)) return;
            
            _currentState?.Exit();
            _currentState = _states[type];
            _currentState.Enter();
        }
    }
}
