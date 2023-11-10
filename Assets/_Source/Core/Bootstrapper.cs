using Core.StateMachine;
using Core.StateMachine.States;
using RingSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private FinalRing _finalRing;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, FinalRing finalRing)
        {
            _gameStateMachine = gameStateMachine;
            _finalRing = finalRing;
        }

        private void Awake()
        {
            _finalRing.OnFinalRingPass += SetPauseState;
        }

        private void Start()
        {
            SetPauseState();
        }

        private void SetPauseState()
        {
            _gameStateMachine.SwitchState<PauseState>();
        }
    }
}