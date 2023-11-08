using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneChanger
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoadSceneBySceneIndex(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}