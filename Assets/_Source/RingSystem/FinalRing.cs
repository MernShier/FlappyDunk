using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace RingSystem
{
    public class FinalRing : Ring
    {
        protected override void Pass(Collider2D passer)
        {
            SceneChanger.LoadSceneBySceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
            base.Pass(passer);
        }
    }
}
