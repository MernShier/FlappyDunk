using BallSystem;
using Collision.Data;
using Core.StateMachine;
using Core.StateMachine.States;
using RingSystem;
using ScoreSystem;
using UnityEngine;
using Utils;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CollisionConfig collisionConfig;
        [SerializeField] private Ball ball;
        [SerializeField] private BallCam ballCam;
        [SerializeField] private FinalRing finalRing;
        
        public override void InstallBindings()
        {
            InstallLevelBindings();
            InstallBallBindings();
            InstallStateMachineBindings();
            InstallScoreBindings();
        }
        
        private void InstallLevelBindings()
        {
            Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<UniversalParent>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<CollisionConfig>().FromInstance(collisionConfig).AsSingle().NonLazy();
            Container.Bind<FinalRing>().FromInstance(finalRing).AsSingle().NonLazy();
            Container.Bind<Game>().AsSingle().NonLazy();
        }

        private void InstallBallBindings()
        {
            Container.Bind<Ball>().FromInstance(ball).AsSingle().NonLazy();
            Container.Bind<BallCam>().FromInstance(ballCam).AsSingle().NonLazy();
            Container.Bind<BallShield>().AsSingle().NonLazy();
        }
        
        private void InstallStateMachineBindings()
        {
            Container.Bind<PauseState>().AsCached().NonLazy();
            Container.Bind<PlayState>().AsCached().NonLazy();
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
        }
        
        private void InstallScoreBindings()
        {
            Container.Bind<Score>().AsSingle().NonLazy();
            Container.Bind<RingScore>().AsSingle().NonLazy();
        }
    }
}