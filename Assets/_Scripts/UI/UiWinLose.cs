using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string nextLevelSceneName = "NextLevel";

    public void InitializeButtons()
    {
        Transform replayButton = transform.Find("ReplayButton");
        if (replayButton != null)
        {
            replayButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartLevel);
        }

        Transform menuButton = transform.Find("MenuButton");
        if (menuButton != null)
        {
            menuButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(GoToMenu);
        }

        Transform nextButton = transform.Find("NextButton");
        if (nextButton != null)
        {
            nextButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(GoToNextLevel);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelSceneName);
    }


}