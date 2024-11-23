using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    public Timer timer; // Référence au Timer
    public GameObject win1StarPanelPrefab;
    public GameObject win2StarsPanelPrefab;
    public GameObject win3StarsPanelPrefab;

    public Transform uiParent; // Parent dans la hiérarchie de la scène pour les panels
    public GameObject confettiPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float elapsedTime = timer.GetTime();

            // Conditions pour afficher les panels correspondants
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

            // Déclencher les confettis
            SpawnConfetti();
        }
    }

    private void ShowPanel(GameObject panelPrefab)
    {
        if (panelPrefab != null && uiParent != null)
        {
            // Instancier le prefab et le placer dans la hiérarchie UI
            GameObject panelInstance = Instantiate(panelPrefab, uiParent);
            panelInstance.SetActive(true);

            // Ajouter les boutons à la logique (via un script WinLoseUI)
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
}
