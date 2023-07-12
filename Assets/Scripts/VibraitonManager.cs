using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibraitonManager : MonoBehaviour
{

    [Header("Settings")]
    private bool haptics;
    // Start is called before the first frame update
    void Start()
    {
       
    }

   

    public void Vibrate()
    {
        Taptic.Light();
        
    }

    public void EnableVibrations()
    {
        haptics = true;
    }

    public void DisableVibrations()
    {
        haptics = false;
    }
}
