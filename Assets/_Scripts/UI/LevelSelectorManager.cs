using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public GameObject levelPanel;
        public Button playButton;
        public string sceneName;
    }

    [SerializeField] private Level[] levels;
    [SerializeField] private Color lockedColor = Color.gray;
    [SerializeField] private Color unlockedColor = Color.white;
    [SerializeField] private Color completedColor = Color.white; 

    private void Start()
    {
        InitializeLevels();
    }

    private void InitializeLevels()
    {
        int highestUnlockedLevel = PlayerPrefs.GetInt("HighestUnlockedLevel", 0);

        for (int i = 0; i < levels.Length; i++)
        {
            bool isUnlocked = (i == 0) || (i <= highestUnlockedLevel);  
            bool isCompleted = SaveManager.IsLevelCompleted(i);

            levels[i].playButton.interactable = isUnlocked;

            Color targetColor = lockedColor;
            if (isCompleted)
            {
                targetColor = completedColor;
            }
            else if (isUnlocked)
            {
                targetColor = unlockedColor;
            }

            levels[i].levelPanel.GetComponent<Image>().color = targetColor;

            int levelIndex = i;
            levels[i].playButton.onClick.RemoveAllListeners();
            levels[i].playButton.onClick.AddListener(() => PlayLevel(levels[levelIndex].sceneName));
        }
    }

    private void PlayLevel(string sceneName)
    {
        Debug.Log($"Chargement de la scène {sceneName}...");
        SceneManager.LoadScene(sceneName);
    }

    // Réinitialise les niveaux et les sauvegardes à leur état initial.
    public void ResetLevelProgress()
    {
        // Réinitialiser la progression et la sauvegarde
        PlayerPrefs.DeleteKey("HighestUnlockedLevel");
        SaveManager.ResetProgress();  

        // Réinitialiser les niveaux dans l'UI
        PlayerPrefs.SetInt("HighestUnlockedLevel", 0); 
        InitializeLevels();

        Debug.Log("Progression des niveaux réinitialisée.");
    }
}
