using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float rotateSpeed;

    private float ScreenWidth;


    void Start()
    {

        ScreenWidth = Screen.width;

    }

    void Update()
    {

        if (GameManager.instance.IsGameState())
        {
            int i = 0;

            if (Input.touchCount > 0)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);

                Time.timeScale = 1f;

            }
            else
            {
                Time.timeScale = 0f;

            }
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(0).position.x > ScreenWidth / 2)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
                    transform.Rotate(Vector3.back, Time.deltaTime * rotateSpeed);
                }

                if (Input.GetTouch(0).position.x < ScreenWidth / 2)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * turnSpeed);
                    transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);

                }
                ++i;
            }
        }

    }


}
