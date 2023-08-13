using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuMove : MonoBehaviour
{
    private bool isPuan = false;
    public int bandSira;
    public bool isX = true;
    private float speed = 0;
    BoxData boxData;

    // Update is called once per frame
    private void Start()
    {
        boxData = transform.parent.GetComponent<BoxData>();
    }
    public void setSpeed(float speed)
    {
        this.speed = speed; 
    }


    void controller()
    {   if(Input.GetKeyDown(KeyCode.D))
        { 
            if (boxData.x1Max > transform.position.x && boxData.x1Min < transform.position.x)
            {
                if (bandSira == 1)
                    isPuan = true;
                if (boxData.x1Min + boxData.tolerans > transform.position.x)
                { transform.position = new Vector3(boxData.x1Min + boxData.tolerans, transform.position.y, transform.position.z); }
                else if (boxData.x1Max - boxData.tolerans < transform.position.x)
                { transform.position = new Vector3(boxData.x1Max - boxData.tolerans, transform.position.y, transform.position.z); }
                isX = false;
            }
              
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (boxData.x2Max > transform.position.x && boxData.x2Min < transform.position.x)
            {
                if (bandSira == 2)
                    isPuan = true;
                if (boxData.x2Min + boxData.tolerans > transform.position.x)
                { transform.position = new Vector3(boxData.x2Min + boxData.tolerans, transform.position.y, transform.position.z); }
                else if (boxData.x2Max - boxData.tolerans < transform.position.x)
                { transform.position = new Vector3(boxData.x2Max - boxData.tolerans, transform.position.y, transform.position.z); }
                isX = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (boxData.x3Max > transform.position.x && boxData.x3Min < transform.position.x)
            {
                if (bandSira == 3)
                    isPuan = true;
                if (boxData.x3Min + boxData.tolerans > transform.position.x)
                { transform.position = new Vector3(boxData.x3Min + boxData.tolerans, transform.position.y, transform.position.z); }
                else if (boxData.x3Max - boxData.tolerans < transform.position.x)
                { transform.position = new Vector3(boxData.x3Max - boxData.tolerans, transform.position.y, transform.position.z); }
                isX = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) /*|| true*/)
        {
            if (bandSira == 4)
                isPuan = true;
            if (boxData.x4Max > transform.position.x && boxData.x4Min < transform.position.x)
            {
                if (boxData.x4Min + boxData.tolerans > transform.position.x)
                { transform.position = new Vector3(boxData.x4Min + boxData.tolerans, transform.position.y, transform.position.z); }
                else if (boxData.x4Max - boxData.tolerans < transform.position.x)
                { transform.position = new Vector3(boxData.x4Max - boxData.tolerans, transform.position.y, transform.position.z); }
                isX = false;
            }
        }
    }
    private void Update()
    {
        controller();
    }
    private void FixedUpdate()
    {
        if (speed != 0)
        {
            if (isX)
            {
                transform.position += new Vector3(boxData.boxSpeed, 0, 0);
            }
            else if (!isX && transform.position.y < 1)
            {
                transform.position += new Vector3(0, 0.5f, 0);
            }
            else
            {
                transform.position += new Vector3(0, boxData.boxSpeed, 0);
            }

            if (transform.position.x > 12 || transform.position.y > 6)
            {
                if (isPuan)
                    boxData.puan++;
                else
                    boxData.puan -= 10;
                Destroy(this.gameObject);
            }
        }
    }
}
