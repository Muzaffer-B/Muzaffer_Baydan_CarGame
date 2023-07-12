using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerLayer.onAnimationReset += Animator;
        PlayerLayer.onObstacleTouched += Animator;

    }
    private void OnDestroy()
    {
        PlayerLayer.onAnimationReset -= Animator;
        PlayerLayer.onObstacleTouched -= Animator;

    }

    private void Animator()
    {
        PlayerContoller[] obj = FindObjectsOfType<PlayerContoller>();
        int j = 0;
        for (int i = obj.Length ; i > 0; i--)
        {
            //Debug.Log("obje adý: " + obj[i-1].name + "obje length: " + obj.Length);
            //Debug.Log("Player" + (j));
            if (i != 1)
            {
                obj[i - 1].GetComponent<Animator>().enabled = true;
                obj[i - 1].GetComponent<Animator>().Rebind();
                obj[i - 1].GetComponent<Animator>().Play("Player" + (j));
                j++;

            }

        }
    }
}
