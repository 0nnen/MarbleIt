using UnityEngine;

public class ResetButtonManager : MonoBehaviour
{
    public LevelSelectorManager levelSelectorManager;

    public void OnResetButtonClicked()
    {
        levelSelectorManager.ResetLevelProgress();
    }
}