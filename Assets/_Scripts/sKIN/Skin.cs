using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Material[] skins; // Liste des skins (matériaux) à assigner
    [SerializeField] private GameObject buttonPrefab; // Préfabriqué pour un bouton (UI)
    [SerializeField] private Transform scrollViewContent; // Conteneur du ScrollView (contenu)

    private void Start()
    {
        // Génère un bouton pour chaque skin dans la liste
        for (int i = 0; i < skins.Length; i++)
        {
            int index = i; // Capture l'index actuel
            CreateSkinButton(skins[index].name, index);
        }
    }

    private void CreateSkinButton(string skinName, int skinIndex)
    {
        // Instancie le bouton préfabriqué
        GameObject buttonObj = Instantiate(buttonPrefab, scrollViewContent);

        // Configure le texte du bouton
        Text buttonText = buttonObj.GetComponentInChildren<Text>();
        buttonText.text = skinName;

        // Configure l'action du bouton
        Button button = buttonObj.GetComponent<Button>();
        button.onClick.AddListener(() => SelectSkin(skinIndex));
    }

    private void SelectSkin(int index)
    {
        // Sauvegarde l'index du skin sélectionné
        PlayerPrefs.SetInt("SelectedSkin", index);
        PlayerPrefs.Save();

        // Debug pour vérifier le skin sélectionné
        Debug.Log($"Skin sélectionné : {skins[index].name}");
    }
}
