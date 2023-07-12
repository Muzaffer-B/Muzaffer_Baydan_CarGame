using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "World", menuName = "Level")]

public class Level : ScriptableObject
{
    

    [Header("Available items")]
    public GameObject Obstacles;

    //public int scoreGoals;

    [Header("Level Requierements")]
    public int obstacleCount;
    

}
