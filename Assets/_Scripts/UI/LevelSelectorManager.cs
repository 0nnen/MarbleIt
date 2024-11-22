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
            Debug.Log($"Level {levelIndex + 1} commencé.");
            Debug.Log($"Level {levelIndex + 1} réussi ! Débloquer le suivant...");
            UnlockNextLevel(levelIndex);
        }
        else
        {
            Debug.Log($"Level {levelIndex + 1} est verrouillé.");
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
}
