using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public TextMeshProUGUI levelText;

    private void Start()
    {
        DisplayLevel();
    }

    public void ReloadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void DisplayLevel()
    {
        if (levelText)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            levelText.text = "Level " + currentSceneIndex.ToString();
        }
    }
}
