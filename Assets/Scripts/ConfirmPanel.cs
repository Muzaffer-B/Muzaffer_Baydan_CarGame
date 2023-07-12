using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ConfirmPanel : MonoBehaviour
{
    [Header("Level Information")]
    [SerializeField] private string levelToLoad;
    private GameData gameData;
    public int level;
    [SerializeField] private int Highscore;

    //[Header("UI")]
    //public TextMeshProUGUI HighScoreText;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        LoadData();
        //SetText();
    }

    public void LoadData()
    {
        // Is Gamedata present
        if (gameData != null)
        {
            // Decide if the level is active
            //Debug.Log("level: "+ level);
            //Highscore = gameData.saveData.highScores[level - 1];
            SetText();

        }
    }

    void SetText()
    {
        //HighScoreText.text = "" + Highscore;
    }

    public void Cancel()
    {
        this.gameObject.SetActive(false);   
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Current Level", level - 1);
        SceneManager.LoadScene(levelToLoad);
    }
}
