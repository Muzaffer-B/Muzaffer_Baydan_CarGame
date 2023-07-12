using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    public static Action onObstacleHit;
    // Update is called once per frame
    void Update()
    {
        DetectColliders();
    }

    private void DetectColliders()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 0.5f);

        for (int i = 0; i < detectedColliders.Length; i++)
        {

            if (detectedColliders[i].tag == "Obstacle")
            {
                //Debug.Log("Obstacle Found on Spawn");
                onObstacleHit?.Invoke();

            }
           

        }
        
    }
}
