using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenuscript : MonoBehaviour
{
    [SerializeField] GameObject levelSelector;
    [SerializeField] GameObject mainMenu;
    string[] sceneTab = { "Level1", "Level2", "Level3" };
    [SerializeField] TextMeshProUGUI text;
    private int currentLevel = 0;

    void Update()
    {
        text.text = sceneTab[currentLevel];
    }
    public void playGame()
    {
        //SceneManager.LoadSceneAsync("LevelSelector");
        mainMenu.SetActive(false);
        levelSelector.SetActive(true);
    }
    public void next()
    {
        if (currentLevel < 2)
        {
            currentLevel++;
        }
    }
    public void previous()
    {
        if (currentLevel > 0)
        {
            currentLevel--;
        }
    }
    public void load()
    {
        print("load" +  sceneTab[currentLevel]);
    }
}
