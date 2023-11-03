using Utils;
using Zenject;

namespace Core
{
    public class ProjectMainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneChanger>().AsSingle().NonLazy();
        }
    }
}