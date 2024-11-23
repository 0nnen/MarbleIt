using UnityEngine;

public static class SaveManager
{
    private const string ProgressKey = "LevelProgress";

    /// <summary>
    /// Sauvegarde la progression d'un niveau comme termin?.
    /// </summary>
    /// <param name="levelIndex">Indice du niveau ? marquer comme termin?.</param>
    public static void SaveLevelProgress(int levelIndex)
    {
        string progressData = PlayerPrefs.GetString(ProgressKey, "");
        if (!progressData.Contains(levelIndex.ToString()))
        {
            progressData += levelIndex + ";";
            PlayerPrefs.SetString(ProgressKey, progressData);
            PlayerPrefs.Save();
            Debug.Log($"Niveau {levelIndex} sauvegard? comme termin?.");
        }
    }

    /// <summary>
    /// V?rifie si un niveau est termin?.
    /// </summary>
    /// <param name="levelIndex">Indice du niveau ? v?rifier.</param>
    /// <returns>True si le niveau est termin?, False sinon.</returns>
    public static bool IsLevelCompleted(int levelIndex)
    {
        string progressData = PlayerPrefs.GetString(ProgressKey, "");
        return progressData.Contains(levelIndex.ToString());
    }

    /// <summary>
    /// R?initialise toute la progression.
    /// </summary>
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey("HighestUnlockedLevel");
        PlayerPrefs.DeleteKey(ProgressKey);
        PlayerPrefs.Save();
        Debug.Log("Progression r?initialis?e.");
    }


}