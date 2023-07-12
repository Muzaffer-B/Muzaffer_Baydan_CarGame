using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform entrance;
    [SerializeField] private Transform exit;
    [SerializeField] private Transform player;

    Vector2[,] entranceArray;
    Vector2[,] exitArray;
    int playerCount;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLayer.onExitTouched += ChangeExitLocation;
        ObstacleDetection.onObstacleHit += ChangeExitLocation;

        

        entranceArray = new Vector2[8, 8];
        exitArray = new Vector2[8, 8];

    }

    private void OnDestroy()
    {
        PlayerLayer.onExitTouched -= ChangeExitLocation;
        ObstacleDetection.onObstacleHit -= ChangeExitLocation;

    }


    private void ChangeExitLocation()
    {
        playerCount = FindObjectsOfType<PlayerContoller>().Length;

        int randExitXPos = Random.Range(-(int)Camera.main.orthographicSize / 2, (int)Camera.main.orthographicSize / 2);
        int randExitYPos = Random.Range(-(int)Camera.main.orthographicSize / 2, (int)Camera.main.orthographicSize );
        Vector2 exitVector = new Vector2(randExitXPos, randExitYPos);

        int randEntranceXPos = Random.Range(-(int)Camera.main.orthographicSize / 2, (int)Camera.main.orthographicSize / 2);
        int randEntranceYPos = Random.Range(-(int)Camera.main.orthographicSize / 2, (int)Camera.main.orthographicSize);
        Vector2 entranceVector = new Vector2(randEntranceXPos, randEntranceYPos);


        

        for (int i = 0; i < playerCount - 1; i++)  // eðer ki entrance ve exit spawn öncekilerle ayný olursa deðiþtir.
        {
            if (entranceArray[i, i] == entranceVector)
            {
                ChangeExitLocation();
            }
            if (exitArray[i, i] == exitVector)
            {
                ChangeExitLocation();
            }
        }
        exit.transform.position = new Vector3(randExitXPos, randExitYPos, exit.transform.position.z);
        entrance.transform.position = new Vector3(randEntranceXPos, randEntranceYPos, entrance.transform.position.z);

        if(i< playerCount - 1)
        {
            entranceArray[i, i] = entranceVector;
            exitArray[i, i] = exitVector;
        }
        
        i++;

        

        player.transform.position = entrance.transform.position;
       

    }

    
}
