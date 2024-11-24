using UnityEngine;

public class BallSkinApplier : MonoBehaviour
{
    [SerializeField] private Material[] skins; // Liste des skins
    [SerializeField] private Renderer ballRenderer; // Renderer de la bille

    private void Start()
    {
        // Récupère l'index du skin sélectionné
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", 0); // 0 par défaut

        // Applique le skin si l'index est valide
        if (selectedSkinIndex >= 0 && selectedSkinIndex < skins.Length)
        {
            ballRenderer.material = skins[selectedSkinIndex];
            Debug.Log($"Skin appliqué : {skins[selectedSkinIndex].name}");
        }
        else
        {
            Debug.LogWarning("Aucun skin valide sélectionné !");
        }
    }
}
