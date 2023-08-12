using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PistonMove : MonoBehaviour
{
    private Transform zemin;
    private Transform itici;
    private PistonData pistonData;
    private int durum = -2;
    public bool h;
    // Start is called before the first frame update
    void Start()
    {
        pistonData = GetComponent<PistonData>();
        zemin = transform.GetChild(0);
        itici = transform.GetChild(1);
        zemin.transform.position = new Vector3(zemin.transform.position.x, pistonData.zeminPositionMinY, zemin.transform.position.z);
        itici.transform.position = new Vector3(itici.transform.position.x, pistonData.iticiPositionMinY, itici.transform.position.z);
        itici.transform.localScale = new Vector3(1, 0.1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        controller();
        if (Input.GetKeyDown(pistonData.tus) || h) {
                durum = 1;
        }
    }

    void controller()
    {
        
        if (durum == 1)
        {
            moveUp();
        }
        else if (durum == -1)
        {
            moveDown();
        }
    }
    private void moveUp()
    {
        
        if (pistonData.zeminPositionMaxY > zemin.transform.position.y)
        {

            print("çalýþtý");
            itici.transform.localScale += new Vector3(0, pistonData.artis, 0);
            itici.transform.position += new Vector3(0, pistonData.artis * 0.85f, 0);
            zemin.transform.position += new Vector3(0, pistonData.artis * 1.72f, 0);
        }
        else
        {
            durum = -1;
        }

    }
    private void moveDown()
    {
        if (pistonData.zeminPositionMinY < zemin.transform.position.y)
        {
            
            itici.transform.localScale -= new Vector3(0, pistonData.artis, 0);
            itici.transform.position -= new Vector3(0, pistonData.artis * 0.85f, 0);
            zemin.transform.position -= new Vector3(0, pistonData.artis * 1.72f, 0);
        }
    }
}
