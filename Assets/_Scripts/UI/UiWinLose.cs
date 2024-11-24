using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinLoseUI : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string nextLevelSceneName = "NextLevel";

    private void Start()
    {
        InitializeButtons();
    }

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

    // M�thode pour red�marrer le niveau
    public void RestartLevel()
    {
        // R�initialiser les donn�es globales si n�cessaire avant de recharger la sc�ne
        ResetGlobalData();

        // R�initialiser les objets sp�cifiques dans la sc�ne
        ResetObjectsInScene();

        // Recharger la sc�ne actuelle imm�diatement
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // D�commenter cette ligne si vous avez besoin de faire un d�lai (mais normalement ce n'est pas n�cessaire)
        // StartCoroutine(RestartLevelCoroutine());
    }

    // M�thode pour r�initialiser les donn�es globales si n�cessaire (ex : niveau actuel, score)
    private void ResetGlobalData()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0); // R�initialiser le niveau, ajustez selon vos besoins
        PlayerPrefs.Save();
        Debug.Log("Donn�es globales r�initialis�es.");
    }

    // M�thode pour r�initialiser les objets sp�cifiques dans la sc�ne
    private void ResetObjectsInScene()
    {
        // Exemple pour r�initialiser ou d�truire un objet sp�cifique
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Player");
        foreach (var obj in objectsToDestroy)
        {
            Destroy(obj);
            Debug.Log($"Objet d�truit : {obj.name}");
        }

        // R�initialisez d'autres objets si n�cessaire
    }

    // M�thode pour retourner au menu principal
    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    // M�thode pour aller au niveau suivant
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelSceneName);
    }
}
