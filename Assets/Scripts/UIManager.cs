using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Buttons")]

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject playLevelButton;
    [SerializeField] private GameObject exitLevelButton;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private GameObject settingsButton;

    [Header("UI Panels")]
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Particles")]
    [SerializeField] private GameObject[] particles;

    [Header("Texts")]
    [SerializeField] private GameObject titleText;


    //VibraitonManager vibraitonManager;


    [Header("Actions")]

    public static Action onButtonTap;
    

    void Start()
    {
        //vibraitonManager = FindAnyObjectByType<VibraitonManager>();

        //LevelButton.onParticleStart += ParticleEnabled;
    }

    private void OnDestroy()
    {
        //LevelButton.onParticleStart -= ParticleEnabled;

    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
        titleText.SetActive(false);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
        titleText.SetActive(true);

    }

    public void OpenPlayButon()
    {
        onButtonTap?.Invoke();
        //vibraitonManager.Vibrate();
        levelPanel.SetActive(true);
        playButton.SetActive(false);
        titleText.SetActive(false);
        settingsButton.SetActive(false);
    }

    public void OpenLevelPlayButon()
    {
        onButtonTap?.Invoke();
        //vibraitonManager.Vibrate();
    }

    public void ExitLevelPlayButon()
    {
        onButtonTap?.Invoke();
        //vibraitonManager.Vibrate();
        confirmPanel.SetActive(false);
    }

    public void HomePlayButon()
    {
        onButtonTap?.Invoke();
        //vibraitonManager.Vibrate();
        levelPanel.SetActive(false);
        playButton?.SetActive(true);
        titleText?.SetActive(true);
        settingsButton?.SetActive(true);
    }

    private void ParticleEnabled()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Opened Level");
        PlayerPrefs.DeleteKey("LevelStatus");
    }
}
