using BallSystem;
using BallSystem.Data;
using Core.StateMachine;
using Core.StateMachine.States;
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
        
        public override void InstallBindings()
        {
            Container.Bind<CollisionConfig>().FromInstance(collisionConfig).AsSingle().NonLazy();
            
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
            Container.Bind<LevelStartState>().AsSingle().NonLazy();
            Container.Bind<PlayState>().AsSingle().NonLazy();
            
            Container.Bind<Ball>().FromInstance(ball).AsSingle().NonLazy();
            Container.Bind<BallCam>().FromInstance(ballCam).AsSingle().NonLazy();
            Container.Bind<BallShield>().AsSingle().NonLazy();
            
            Container.Bind<Scorer>().AsSingle().NonLazy();
            Container.Bind<RingScore>().AsSingle().NonLazy();

            Container.Bind<Game>().AsSingle().NonLazy();
            Container.Bind<SceneChanger>().AsSingle().NonLazy();
        }
    }
}