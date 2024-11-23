using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsPopup;
    [SerializeField] private GameObject storePopup;
    [SerializeField] private GameObject settingsPopup;
    [SerializeField] private GameObject messagePopup;
    [SerializeField] private GameObject skinPopup;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource buttonClickSound;
    /*    [SerializeField] private AudioSource backgroundMusic;
    */
    [Header("Sliders")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;

    private string[] sceneTab = { "Test", "LEVEL_02", "LEVEL_03" };
    private int currentLevel = 0;
    private const string CurrentLevelKey = "CurrentLevel";
    private void Start()
    {
        // V�rification de la musique en arri�re-plan
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().gameObject.SetActive(true);
            gameObject.GetComponent<AudioSource>().loop = true;

            // Initialisation du volume de la musique
            if (gameObject.GetComponent<AudioSource>().volume == 0)
            {
                gameObject.GetComponent<AudioSource>().volume = 0.5f;
            }

            gameObject.GetComponent<AudioSource>().Play();

            // Initialisation du slider de volume avec la valeur actuelle de l'AudioSource
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                musicVolumeSlider.value = gameObject.GetComponent<AudioSource>().volume;
            }
        }
        else
        {
            Debug.LogWarning("Aucune AudioSource assign�e � backgroundMusic !");
        }

        if (buttonClickSound != null)
        {
            if (soundVolumeSlider != null)
            {
                soundVolumeSlider.value = buttonClickSound.volume;
            }
        }
        else
        {
            Debug.LogWarning("Aucune AudioSource assign�e pour le son des boutons !");
        }


    }

    public void SetMusicVolume()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().volume = musicVolumeSlider.value;
            Debug.Log($"Volume de la musique mis � jour : {musicVolumeSlider.value}");
        }
        else
        {
            Debug.LogWarning("Aucune AudioSource assign�e � backgroundMusic !");
        }
    }



    // M�thode de mise � jour du volume du son des boutons
    private void SetSoundVolume()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.volume = soundVolumeSlider.value;
            Debug.Log($"Volume du son des boutons mis � jour : {soundVolumeSlider.value}");
        }
        else
        {
            Debug.LogWarning("Aucun AudioSource assign� pour le son des boutons !");
        }
    }

    // M�thode pour jouer le son du bouton
    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
        else
        {
            Debug.LogWarning("Aucun AudioSource assign� pour le son des boutons !");
        }
    }

    public void PlayGame()
    {
        PlayButtonClickSound();

        // Charger le niveau actuel depuis la sauvegarde
        currentLevel = GetCurrentLevel();

        // Vérifier si le niveau existe dans la liste
        if (currentLevel < sceneTab.Length)
        {
            string sceneToLoad = sceneTab[currentLevel];
            Debug.Log($"Chargement du niveau : {sceneToLoad}");
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Tous les niveaux ont été complétés ou niveau invalide !");
        }
    }


    public void ShowCredits()
    {
        PlayButtonClickSound();
        ShowPanel(creditsPopup);
    }

    public void ShowStore()
    {
        PlayButtonClickSound();
        ShowPanel(storePopup);
    }

    public void ShowSettings()
    {
        PlayButtonClickSound();
        ShowPanel(settingsPopup);
    }

    public void ShowMessage()
    {
        PlayButtonClickSound();
        ShowPanel(messagePopup);
    }

    public void ShowLevel()
    {
        PlayButtonClickSound();
        ShowPanel(levelSelector);
    }

    public void ShowSkinPopup()
    {
        PlayButtonClickSound();
        ShowPanel(skinPopup);
    }

    public void BackToMenu()
    {
        PlayButtonClickSound();
        HideAllPanels();
        if (mainMenu != null)
        {
            mainMenu.SetActive(true);
        }
    }

    private void ShowPanel(GameObject panel)
    {
        if (panel != null)
        {
            HideAllPanels();
            panel.SetActive(true);
        }
    }

    private void HideAllPanels()
    {
        if (creditsPopup != null) creditsPopup.SetActive(false);
        if (storePopup != null) storePopup.SetActive(false);
        if (settingsPopup != null) settingsPopup.SetActive(false);
        if (messagePopup != null) messagePopup.SetActive(false);
        if (levelSelector != null) levelSelector.SetActive(false);
        if (skinPopup != null) skinPopup.SetActive(false);
        if (mainMenu != null) mainMenu.SetActive(false);
    }

    public void UseSkin(string skinName)
    {
        PlayButtonClickSound();
        Debug.Log($"Skin activ� : {skinName}");
    }
    private int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt(CurrentLevelKey, 0); // Par défaut, niveau 0
    }

    private void SaveCurrentLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(CurrentLevelKey, levelIndex);
        PlayerPrefs.Save();
        Debug.Log($"Niveau actuel sauvegardé : {levelIndex}");
    }

    public void UnlockNextLevel()
    {
        int currentLevel = GetCurrentLevel();

        // Vérifier si on peut débloquer un niveau supplémentaire
        if (currentLevel + 1 < sceneTab.Length)
        {
            SaveCurrentLevel(currentLevel + 1);
            Debug.Log($"Prochain niveau débloqué : {currentLevel + 1}");
        }
        else
        {
            Debug.Log("Tous les niveaux sont déjà débloqués.");
        }
    }

}