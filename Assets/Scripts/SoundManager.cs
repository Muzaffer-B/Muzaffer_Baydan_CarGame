using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("Sounds")]
    
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource playItemTapSound;


    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangeCallback;
        
        UIManager.onButtonTap += PlayItemTapSound;
    }

     void OnDestroy()
    {
        

        GameManager.onGameStateChanged -= GameStateChangeCallback;
 
        UIManager.onButtonTap -= PlayItemTapSound;

    }

    private void GameStateChangeCallback( GameState gameState)
    {
        if (gameState == GameState.LevelComplete)
        {
            levelCompleteSound.Play();
        }
       
    }

    public void PlayItemTapSound()
    {
        playItemTapSound.Play();
    }

   

    public void DisableSounds()
    {
       
        levelCompleteSound.volume = 0;
        playItemTapSound.volume = 0;

    }
    public void EnableSounds()
    {
        
        levelCompleteSound.volume = 1;
        playItemTapSound.volume = 1;


    }
}
