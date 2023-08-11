using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuMove : MonoBehaviour
{
    public float speed = 0.001f;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (transform.position.x > 10)
            transform.position = new Vector3(-8, 0, -2);
    }
}
