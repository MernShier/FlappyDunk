using BallSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Ball ball;
        public override void InstallBindings()
        {
            Container.Bind<Ball>().FromInstance(ball).AsSingle().NonLazy();
        }
    }
}