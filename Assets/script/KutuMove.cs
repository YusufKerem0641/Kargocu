using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuMove : MonoBehaviour
{
    public float speed = 0;

    // Update is called once per frame
    public void setSpeed(float s)
    {
        speed = s;
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (transform.position.x > 12 || transform.position.y > 4.5f)
            Destroy(this.gameObject);
    }
}
