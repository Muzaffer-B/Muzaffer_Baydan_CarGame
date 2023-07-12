using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerLayer : MonoBehaviour
{
    public static Action onExitTouched;
    public static Action onCountReached;
    public static Action onObstacleTouched;

    public static Action onAnimationReset;

    public GameObject playerPrefab; 
    [SerializeField] private Transform entranceTransfrom;
    Animator anim;
    [SerializeField] private bool hastouched;
    private void Start()
    {
        entranceTransfrom = GameObject.FindGameObjectWithTag("Entrance").transform;
        this.gameObject.transform.position = entranceTransfrom.position;
        anim = this.gameObject.GetComponent<Animator>();
    }



    private void OnCollisionEnter(Collision collision)
    {
       
        if (!hastouched)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                //Debug.Log("Obscatle deydi");
                this.gameObject.transform.position = entranceTransfrom.position;
                onObstacleTouched?.Invoke();
            }
            if (collision.gameObject.CompareTag("Limit"))
            {
                //Debug.Log("Obscatle deydi");
                this.gameObject.transform.position = entranceTransfrom.position;
                onObstacleTouched?.Invoke();
            }
            if (collision.gameObject.CompareTag("Exit"))
            {
                onCountReached?.Invoke();

                if (GameManager.instance.IsGameState())
                {
                    onExitTouched?.Invoke();

                    //GameObject prefabObj = Instantiate(playerPrefab, entranceTransfrom.position, Quaternion.identity);
                    int playerCount = FindObjectsOfType<PlayerContoller>().Length;
                    GameObject prefabObj = ObjectPool.instance.GetPoolObject(playerCount-1);
                    prefabObj.SetActive(true);
                    prefabObj.GetComponent<Animator>().enabled = false;
                    anim.enabled = true;
                    //Animator();
                    onAnimationReset?.Invoke();

                    this.gameObject.GetComponent<RecordTransform>().enabled = false;
                    GameManager.instance.SetPlayerCount(GetPlayersCount());

                    //this.anim.Play("Player" + GetAnimationsCount());

                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
                    hastouched = true;

                    this.gameObject.transform.position = entranceTransfrom.position;

                    this.gameObject.GetComponent<PlayerLayer>().enabled = false;
                    //gameObject.transform.position = entranceTransfrom.position;
                }

            }
        }
        if (!hastouched) 
        {
            if (collision.gameObject.CompareTag("Player")) // daha önce oluşmuş karakterlere çarpma kodu.Eğer ki onlar da kendi içerisinde çarpışsın istenirse  if methodu !hastouched olmadan yazılmalıdır.
            {
                //Debug.Log("Obscatle deydi");
                if (GameManager.instance.IsGameState())
                {
                    this.gameObject.transform.position = entranceTransfrom.position;
                    onObstacleTouched?.Invoke();
                    onAnimationReset?.Invoke();

                }

            }
        }
       

    }

 
    //private void Animator()
    //{
    //    PlayerContoller[] obj = FindObjectsOfType<PlayerContoller>();
    //    for (int i = 0; i < obj.Length -1; i++)
    //    {
    //        Debug.Log("obje ad�: " + obj[i].name);

    //        obj[i].GetComponent<Animator>().Play("Player"+(i+1));
    //    }
    //}

    private int GetPlayersCount()
    {
        //Debug.Log("Players length:" + FindObjectsOfType<PlayerContoller>().Length);
        return FindObjectsOfType<PlayerContoller>().Length;
    }
    private int GetAnimationsCount()
    {
        //Debug.Log("Players length:" + FindObjectsOfType<PlayerContoller>().Length);
        return FindObjectsOfType<PlayerContoller>().Length - 2;
    }
}
