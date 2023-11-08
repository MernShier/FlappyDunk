using UnityEngine.SceneManagement;

namespace Utils
{
    public static class SceneChanger
    {
        public static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public static void LoadSceneBySceneIndex(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}