using UnityEngine;

public static class SaveManager
{
    private const string ProgressKey = "LevelProgress";

    /// <summary>
    /// Sauvegarde la progression d'un niveau comme terminé.
    /// </summary>
    /// <param name="levelIndex">Indice du niveau à marquer comme terminé.</param>
    public static void SaveLevelProgress(int levelIndex)
    {
        string progressData = PlayerPrefs.GetString(ProgressKey, ""); 
        if (!progressData.Contains(levelIndex.ToString()))
        {
            progressData += levelIndex + ";"; 
            PlayerPrefs.SetString(ProgressKey, progressData);
            PlayerPrefs.Save();
            Debug.Log($"Niveau {levelIndex} sauvegardé comme terminé.");
        }
    }

    /// <summary>
    /// Vérifie si un niveau est terminé.
    /// </summary>
    /// <param name="levelIndex">Indice du niveau à vérifier.</param>
    /// <returns>True si le niveau est terminé, False sinon.</returns>
    public static bool IsLevelCompleted(int levelIndex)
    {
        string progressData = PlayerPrefs.GetString(ProgressKey, "");
        return progressData.Contains(levelIndex.ToString());
    }

    /// <summary>
    /// Réinitialise toute la progression.
    /// </summary>
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey("HighestUnlockedLevel");  
        PlayerPrefs.DeleteKey(ProgressKey);  
        PlayerPrefs.Save();
        Debug.Log("Progression réinitialisée.");
    }


}
