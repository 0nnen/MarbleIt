using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsPopup;
    [SerializeField] private GameObject storePopup;
    [SerializeField] private GameObject settingsPopup;
    [SerializeField] private GameObject messagePopup;
    [SerializeField] private GameObject skinPopup; 

    private string[] sceneTab = { "Level1", "Level2", "Level3" };
    private int currentLevel = 0;

    public void PlayGame()
    {
        string sceneToLoad = sceneTab[currentLevel];
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowCredits()
    {
        if (creditsPopup != null && mainMenu != null)
        {
            creditsPopup.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void ShowStore()
    {
        if (storePopup != null && mainMenu != null)
        {
            storePopup.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void ShowSettings()
    {
        if (settingsPopup != null && mainMenu != null)
        {
            settingsPopup.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void ShowMessage()
    {
        if (messagePopup != null && mainMenu != null)
        {
            messagePopup.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void ShowLevel()
    {
        if (levelSelector != null && mainMenu != null)
        {
            levelSelector.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void ShowSkinPopup()
    {
        if (skinPopup != null && mainMenu != null)
        {
            skinPopup.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        if (creditsPopup != null) creditsPopup.SetActive(false);
        if (storePopup != null) storePopup.SetActive(false);
        if (settingsPopup != null) settingsPopup.SetActive(false);
        if (messagePopup != null) messagePopup.SetActive(false);
        if (levelSelector != null) levelSelector.SetActive(false);
        if (skinPopup != null) skinPopup.SetActive(false);

        if (mainMenu != null)
        {
            mainMenu.SetActive(true);
        }
    }

    private void EnsureMainMenuActive()
    {
        if (!mainMenu.activeSelf && !creditsPopup.activeSelf && !storePopup.activeSelf &&
            !settingsPopup.activeSelf && !messagePopup.activeSelf && !levelSelector.activeSelf &&
            !skinPopup.activeSelf)
        {
            mainMenu.SetActive(true);
        }
    }

    public void UseSkin(string skinName)
    {
        Debug.Log($"Skin activé : {skinName}");
    }
}
