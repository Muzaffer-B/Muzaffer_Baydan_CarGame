using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> poolItemList = new List<GameObject>();
    public GameObject playerPrefab;

    public World world;
    public int level;
    int count;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if (PlayerPrefs.HasKey("Current Level"))
        {
            level = PlayerPrefs.GetInt("Current Level");
        }

        if (world != null)
        {
            if (level < world.levels.Length)
            {
                if (world.levels[level] != null)
                {
                    //width = world.levels[level].width;
                    //height = world.levels[level].height;
                    count = world.levels[level].obstacleCount;
                }
            }

        }



        for (int i = 0; i < count -1 ; i++)
        {
            GameObject obj = Instantiate(playerPrefab,transform);
            obj.SetActive(false);
            poolItemList.Add(obj);
        }
    }
   

    public GameObject GetPoolObject(int index)
    {
        
        
       if(poolItemList.Count > 0)
        {
            return poolItemList[index];
        }
        return null;
       
            
                
        
        
    }
}
