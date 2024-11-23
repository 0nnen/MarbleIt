using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    public Timer timer; // R�f�rence au Timer
    public GameObject win1StarPanelPrefab;
    public GameObject win2StarsPanelPrefab;
    public GameObject win3StarsPanelPrefab;

    public Transform uiParent; // Parent dans la hi�rarchie de la sc�ne pour les panels
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
                Debug.Log("Victoire avec 3 �toiles !");
            }
            else if (elapsedTime <= 20f)
            {
                ShowPanel(win2StarsPanelPrefab);
                Debug.Log("Victoire avec 2 �toiles !");
            }
            else if (elapsedTime <= 30f)
            {
                ShowPanel(win1StarPanelPrefab);
                Debug.Log("Victoire avec 1 �toile !");
            }
            else
            {
                Debug.Log("Temps �coul�, pas de victoire !");
            }

            // D�clencher les confettis
            SpawnConfetti();
        }
    }

    private void ShowPanel(GameObject panelPrefab)
    {
        if (panelPrefab != null && uiParent != null)
        {
            // Instancier le prefab et le placer dans la hi�rarchie UI
            GameObject panelInstance = Instantiate(panelPrefab, uiParent);
            panelInstance.SetActive(true);

            // Ajouter les boutons � la logique (via un script WinLoseUI)
            WinLoseUI winLoseUI = panelInstance.GetComponent<WinLoseUI>();
            if (winLoseUI != null)
            {
                winLoseUI.InitializeButtons();
            }
        }
        else
        {
            Debug.LogWarning("PanelPrefab ou UI Parent non assign� !");
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
