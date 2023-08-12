using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCreate : MonoBehaviour
{
    private BoxData boxData;

    private void Start()
    {
        boxData = GetComponent<BoxData>();
        Invoke("boxCreat", boxData.currentDelay);
    }

    private void boxCreat()
    {
        int randomInt = Random.Range(0, 6); // 1 ile 6 arasýnda

        // Prefab'ten yeni bir nesne oluþturma
        GameObject newObject = Instantiate(boxData.prefabs[randomInt], boxData.parentTransform);
        newObject.GetComponent<KutuMove>().setSpeed(boxData.boxSpeed);

        // Yeni nesneyi istediðiniz konum ve döndürmeyle yerleþtirme (opsiyonel)
        newObject.transform.localPosition = new Vector3(-9f, -1.1f, 8f); // Örnek konum
        newObject.transform.localRotation = Quaternion.identity; // Örnek döndürme

        boxData.count++;

        // Bir sonraki çaðrýyý belirtilen gecikmeyle planla
        Invoke("boxCreat", boxData.currentDelay);
    }
    void Update()
    {
        
    }
}
