using BallSystem;
using BallSystem.Data;
using UnityEngine;
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
            
            Container.Bind<Ball>().FromInstance(ball).AsSingle().NonLazy();
            Container.Bind<BallCam>().FromInstance(ballCam).AsSingle().NonLazy();

            Container.Bind<BallScore>().AsSingle().NonLazy();
            Container.Bind<BallShield>().AsSingle().NonLazy();
        }
    }
}