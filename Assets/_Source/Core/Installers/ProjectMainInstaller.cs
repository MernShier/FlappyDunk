using AudioSystem;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class ProjectMainInstaller : MonoInstaller
    {
        [SerializeField] private AudioController audioController;
        public override void InstallBindings()
        {
            Container.Bind<AudioController>().FromInstance(audioController).AsSingle().NonLazy();
        }
    }
}