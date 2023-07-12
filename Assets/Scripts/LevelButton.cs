using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("Active Stuff")]
    public bool isActive;
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite lockedSprite;
    private Image buttonImage;
    private Button myButton;
    [SerializeField] private TextMeshProUGUI levelText;

    [Header("Level UI")]
    [SerializeField] private int level;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private GameObject LevelPanel;
    [SerializeField] private GameObject PlayButton;

    private GameData gameData;

    public static Action onParticleStart;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        buttonImage = GetComponent<Image>();
        myButton = GetComponent<Button>();


        LoadData();
        ShowLevel();
        DecideSprite();
    }

    
    void LoadData()
    {
        // Is Gamedata present
        if(gameData != null)
        {
            // Decide if the leve is active
            if (gameData.saveData.isActive[level -1])
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }


        }
    }

    void DecideSprite()
    {
        if(isActive)
        {
            if(PlayerPrefs.GetInt("Opened Level",-1) == level -1 && PlayerPrefs.GetString("LevelStatus") == "LevelComplete")
            {
                //buttonImage.sprite = lockedSprite;
                //myButton.enabled = false;
                //levelText.enabled = false;
                //Debug.Log("Animation baþlýyor");
                onParticleStart?.Invoke();

                PlayerPrefs.DeleteKey("LevelStatus");
                gameObject.GetComponent<Animator>().enabled = true;
                //myButton.enabled = true;
                //levelText.enabled = true;
                //buttonImage.sprite = activeSprite;
                Invoke("CloseAnimation", 2);
                //Debug.Log("Animation bitti");

            }
            else
            {
                buttonImage.sprite = activeSprite;
                myButton.enabled = true;
                levelText.enabled = true;
            }
            
        }
        else
        {
            buttonImage.sprite = lockedSprite;
            myButton.enabled = false;
            levelText.enabled = false;

        }
    }

   
    void CloseAnimation()
    {
        gameObject.GetComponent<Animator>().enabled = false;

    }
    void ShowLevel()
    {
        levelText.text = "" + level;
    }

    public void ConfirmPanel(int level)
    {
        confirmPanel.GetComponent<ConfirmPanel>().level = level;
        confirmPanel.SetActive(true);
        confirmPanel.GetComponent<ConfirmPanel>().LoadData();
    }
}
