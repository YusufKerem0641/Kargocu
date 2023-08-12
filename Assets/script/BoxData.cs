using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxData : MonoBehaviour
{
    public GameObject[] prefabs; // Prefab nesnesi
    public Transform parentTransform; // Alt nesne olarak eklenecek üst nesne
    public float currentDelay = 1.0f;
    public int count = 0;
    public float boxSpeed = 0.05f;
}
