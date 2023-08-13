using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxCreate : MonoBehaviour
{
    private BoxData boxData;
    public GameObject ekranPrfefab;
    GameObject desDont;

    private void Start()
    {
        desDont = GameObject.Find("dontDestroy");
        boxData = GetComponent<BoxData>();
        Invoke("boxCreat", 0);
        if (desDont)
            desDont.GetComponent<DontDestroy>().puanMax = 0;
    }

    private void boxCreat()
    {
        int randomInt = Random.Range(0, 4); // 1 ile 6 arasýnda

        // Prefab'ten yeni bir nesne oluþturma
        GameObject newObject = Instantiate(boxData.prefabs[randomInt], boxData.parentTransform);
        newObject.GetComponent<KutuMove>().setSpeed(boxData.boxSpeed);
        

        // Yeni nesneyi istediðiniz konum ve döndürmeyle yerleþtirme (opsiyonel)
        newObject.transform.localPosition = new Vector3(-9f, -1.6f, 8f); // Örnek konum
        newObject.transform.localRotation = Quaternion.identity; // Örnek döndürme

        ReplaceGameObjectWithPrefab(boxData.prefabs[randomInt]);
        boxData.count++;

        // Bir sonraki çaðrýyý belirtilen gecikmeyle planla
        Invoke("boxCreat", boxData.currentDelay);
    }

    private void ReplaceGameObjectWithPrefab(GameObject prefab) // prefab yer deðiþtirme
    {
        Vector3 position = transform.position;
        GameObject newObject = Instantiate(prefab, boxData.parentTransform);
        newObject.transform.position = ekranPrfefab.transform.position;
        Destroy(ekranPrfefab); // Eski GameObject'i sil
        ekranPrfefab = newObject;
    }

    void gameSpeed()
    {
        if (boxData.count % boxData.hizlanmaCount == 0)
        {
            boxData.count = 1;
            if (boxData.minDelay < boxData.currentDelay)
                boxData.currentDelay -= boxData.hizlanmaTime;
            if (boxData.maxSpeed > boxData.boxSpeed)
                boxData.boxSpeed += boxData.hizlanmaSpeed;
        }
        if (boxData.puan > boxData.maxPuan)
        {
            boxData.maxPuan = boxData.puan;
            if (desDont)
                desDont.GetComponent<DontDestroy>().puanMax = boxData.maxPuan;
        }
    }
    void Update()
    {
        gameSpeed();
        boxData.puanText.text = boxData.puan.ToString();
        if (boxData.puan < 0)
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Mevcut sahnenin index numarasýný al
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Son sahneye ulaþýldý.");
        }
    }
}
