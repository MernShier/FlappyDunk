using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Zenject;

namespace RingSystem
{
    public class FinalRing : Ring
    {
        private SceneChanger _sceneChanger;

        [Inject]
        private void Construct(SceneChanger sceneChanger)
        {
            _sceneChanger = sceneChanger;
        }
        
        protected override void Pass(Transform passer)
        {
            _sceneChanger.LoadSceneBySceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
            base.Pass(passer);
        }
    }
}
