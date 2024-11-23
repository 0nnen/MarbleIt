using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public GameObject levelPanel; 
        public Button playButton;    
    }

    [SerializeField] private Level[] levels; 
    [SerializeField] private Color lockedColor = Color.gray; 
    [SerializeField] private Color unlockedColor = Color.white;

    private int unlockedLevelIndex = 0; 

    private void Start()
    {
        InitializeLevels();
    }

    private void InitializeLevels()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            bool isUnlocked = i <= unlockedLevelIndex;

            levels[i].playButton.interactable = isUnlocked;

            Color targetColor = isUnlocked ? unlockedColor : lockedColor;
            levels[i].levelPanel.GetComponent<Image>().color = targetColor;

            int levelIndex = i; 
            levels[i].playButton.onClick.AddListener(() => PlayLevel(levelIndex));
        }
    }

    private void PlayLevel(int levelIndex)
    {
        if (levelIndex <= unlockedLevelIndex)
        {
            Debug.Log($"Level {levelIndex + 1} commenc�.");
            Debug.Log($"Level {levelIndex + 1} r�ussi ! D�bloquer le suivant...");
            UnlockNextLevel(levelIndex);
        }
        else
        {
            Debug.Log($"Level {levelIndex + 1} est verrouill�.");
        }
    }

    private void UnlockNextLevel(int currentLevelIndex)
    {
        if (currentLevelIndex + 1 < levels.Length)
        {
            unlockedLevelIndex = currentLevelIndex + 1;
            InitializeLevels(); 
        }
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
