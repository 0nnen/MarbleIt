using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Material[] skins; // Liste des skins (mat�riaux) � assigner
    [SerializeField] private GameObject buttonPrefab; // Pr�fabriqu� pour un bouton (UI)
    [SerializeField] private Transform scrollViewContent; // Conteneur du ScrollView (contenu)

    private void Start()
    {
        // G�n�re un bouton pour chaque skin dans la liste
        for (int i = 0; i < skins.Length; i++)
        {
            int index = i; // Capture l'index actuel
            CreateSkinButton(skins[index].name, index);
        }
    }

    private void CreateSkinButton(string skinName, int skinIndex)
    {
        // Instancie le bouton pr�fabriqu�
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
        // Sauvegarde l'index du skin s�lectionn�
        PlayerPrefs.SetInt("SelectedSkin", index);
        PlayerPrefs.Save();

        // Debug pour v�rifier le skin s�lectionn�
        Debug.Log($"Skin s�lectionn� : {skins[index].name}");
    }
}
