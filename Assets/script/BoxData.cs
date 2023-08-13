using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxData : MonoBehaviour
{
    public GameObject[] prefabs; // Prefab nesnesi
    public Transform parentTransform; // Alt nesne olarak eklenecek üst nesne
    public float currentDelay = 10.0f;
    public float minDelay = 1f;
    public int count = 1;

    public BandHýz band;
    public float boxSpeed = 0.005f;
    public float maxSpeed = 0.1f;

    public float bandSpeed = 1;
    public float bandSpeedKatsayi = 0.1f;

    public float x1Max;
    public float x1Min;
    public float x2Max;
    public float x2Min;
    public float x3Max;
    public float x3Min;
    public float x4Max;
    public float x4Min;

    public int puan;
    public int maxPuan;
    public Text puanText;

    public float tolerans = 0.4f;

    public int hizlanmaCount = 10;
    public float hizlanmaKatSayisi;
    public float hizlanmaTime = 0.1f;
    public float hizlanmaSpeed = 0.001f;

}
