using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(int _levelID)
    {
        var levelName = new StringBuilder("Level ");
        levelName.Append(_levelID);
        SceneManager.LoadScene(levelName.ToString());
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
