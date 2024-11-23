using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string nextLevelSceneName = "NextLevel"; // Nom de la scène suivante (modifiable dans l'inspecteur)

    // Appelé par le script `FinishLineTrigger` pour initialiser les boutons
    public void InitializeButtons()
    {
        // Exemple : Associer un bouton "Rejouer" au restart
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName); // Charge la scène du menu
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelSceneName); // Charge la scène du niveau suivant
    }
}
