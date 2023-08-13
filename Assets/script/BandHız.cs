using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandHız : MonoBehaviour
{
    public float newSpeed = 2.0f; // Hızı iki katına çıkarmak

    public void animationSpeed( float newSpeed)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.GetComponent<Animator>().SetFloat("Speed", newSpeed); // Animator hızını belirtilen hız değerine ayarlama
        }
    }

}
