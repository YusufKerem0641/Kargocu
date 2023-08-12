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
        int randomInt = Random.Range(0, 6); // 1 ile 6 aras�nda

        // Prefab'ten yeni bir nesne olu�turma
        GameObject newObject = Instantiate(boxData.prefabs[randomInt], boxData.parentTransform);
        newObject.GetComponent<KutuMove>().setSpeed(boxData.boxSpeed);

        // Yeni nesneyi istedi�iniz konum ve d�nd�rmeyle yerle�tirme (opsiyonel)
        newObject.transform.localPosition = new Vector3(-9f, -1.1f, 8f); // �rnek konum
        newObject.transform.localRotation = Quaternion.identity; // �rnek d�nd�rme

        boxData.count++;

        // Bir sonraki �a�r�y� belirtilen gecikmeyle planla
        Invoke("boxCreat", boxData.currentDelay);
    }
    void Update()
    {
        
    }
}
