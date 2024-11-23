using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    public Timer timer;
    public GameObject win1StarPanelPrefab;
    public GameObject win2StarsPanelPrefab;
    public GameObject win3StarsPanelPrefab;

    public Transform uiParent;
    public GameObject confettiPrefab;

    [SerializeField] private int currentLevelIndex; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float elapsedTime = timer.GetTime();

            if (elapsedTime <= 10f)
            {
                ShowPanel(win3StarsPanelPrefab);
                Debug.Log("Victoire avec 3 étoiles !");
            }
            else if (elapsedTime <= 20f)
            {
                ShowPanel(win2StarsPanelPrefab);
                Debug.Log("Victoire avec 2 étoiles !");
            }
            else if (elapsedTime <= 30f)
            {
                ShowPanel(win1StarPanelPrefab);
                Debug.Log("Victoire avec 1 étoile !");
            }
            else
            {
                Debug.Log("Temps écoulé, pas de victoire !");
            }

            SpawnConfetti();

            UnlockNextLevel();
        }
    }

    private void ShowPanel(GameObject panelPrefab)
    {
        if (panelPrefab != null && uiParent != null)
        {
            GameObject panelInstance = Instantiate(panelPrefab, uiParent);
            panelInstance.SetActive(true);

            WinLoseUI winLoseUI = panelInstance.GetComponent<WinLoseUI>();
            if (winLoseUI != null)
            {
                winLoseUI.InitializeButtons();
            }
        }
        else
        {
            Debug.LogWarning("PanelPrefab ou UI Parent non assigné !");
        }
    }

    private void SpawnConfetti()
    {
        if (confettiPrefab != null)
        {
            Instantiate(confettiPrefab, transform.position, Quaternion.identity);
        }
    }

    private void UnlockNextLevel()
    {
        int highestUnlockedLevel = PlayerPrefs.GetInt("HighestUnlockedLevel", 0);

        SaveManager.SaveLevelProgress(currentLevelIndex);

        if (currentLevelIndex + 1 > highestUnlockedLevel)
        {
            PlayerPrefs.SetInt("HighestUnlockedLevel", currentLevelIndex + 1);
            PlayerPrefs.Save();
            Debug.Log($"Niveau {currentLevelIndex + 1} débloqué !");
        }
    }
}
