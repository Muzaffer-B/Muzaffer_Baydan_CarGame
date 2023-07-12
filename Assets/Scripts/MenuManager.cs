using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject LevelPanel;
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private GameObject titleObject;

    void Start()
    {
        if (PlayerPrefs.GetString("LevelStatus") == "LevelComplete")
        {
            PlayButton.SetActive(false);
            titleObject.SetActive(false);
            LevelPanel.SetActive(true);
        }
        //Debug.Log("is level complete:" + Board.instance.IsLevelCompletedState());
    }

    
}
