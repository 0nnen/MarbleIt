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

    // Méthode pour redémarrer le niveau
    public void RestartLevel()
    {
        // Réinitialiser les données globales si nécessaire avant de recharger la scène
        ResetGlobalData();

        // Réinitialiser les objets spécifiques dans la scène
        ResetObjectsInScene();

        // Recharger la scène actuelle immédiatement
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Décommenter cette ligne si vous avez besoin de faire un délai (mais normalement ce n'est pas nécessaire)
        // StartCoroutine(RestartLevelCoroutine());
    }

    // Méthode pour réinitialiser les données globales si nécessaire (ex : niveau actuel, score)
    private void ResetGlobalData()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0); // Réinitialiser le niveau, ajustez selon vos besoins
        PlayerPrefs.Save();
        Debug.Log("Données globales réinitialisées.");
    }

    // Méthode pour réinitialiser les objets spécifiques dans la scène
    private void ResetObjectsInScene()
    {
        // Exemple pour réinitialiser ou détruire un objet spécifique
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Player");
        foreach (var obj in objectsToDestroy)
        {
            Destroy(obj);
            Debug.Log($"Objet détruit : {obj.name}");
        }

        // Réinitialisez d'autres objets si nécessaire
    }

    // Méthode pour retourner au menu principal
    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    // Méthode pour aller au niveau suivant
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelSceneName);
    }
}
