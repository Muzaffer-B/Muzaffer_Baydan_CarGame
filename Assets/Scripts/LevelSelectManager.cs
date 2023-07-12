using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject currentPanel;

    [Header("Variables")]
    [SerializeField] private int page;
    [SerializeField] private int currentLevel = 0;

    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        if(gameData != null)
        {
            for (int i = 0; i < gameData.saveData.isActive.Length; i++)
            {
                if (gameData.saveData.isActive[i])
                {
                    currentLevel = i;
                }
            }
        }

        page = (int)Mathf.Floor(currentLevel / 9);

        currentPanel = panels[page];
        panels[page].SetActive(true);
    }

    public void pageRight()
    {
        if(page < panels.Length-1)
        {
            currentPanel.SetActive(false);
            page++;
            currentPanel = panels[page];
            currentPanel.SetActive(true);
        }
    }

    public void pageLeft()
    {
        if (page > 0)
        {
            currentPanel.SetActive(false);
            page--;
            currentPanel = panels[page];
            currentPanel.SetActive(true);
        }
    }
}
