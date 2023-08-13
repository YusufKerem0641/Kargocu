using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    // Start is called before the first frame update
    public KutuMove kutuMove;
    void Start()
    {
        kutuMove = GetComponent<KutuMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kutuMove != null)
        {
            if (Input.GetKeyDown(KeyCode.D) && kutuMove.bandSira == 1)
                kutuMove.setSpeed(1);
            else if (Input.GetKeyDown(KeyCode.F) && kutuMove.bandSira == 2)
                kutuMove.setSpeed(1);
            else if (Input.GetKeyDown(KeyCode.J) && kutuMove.bandSira == 3)
                kutuMove.setSpeed(1);
            else if (Input.GetKeyDown(KeyCode.K) && kutuMove.bandSira == 4)
                kutuMove.setSpeed(1);
        }
    }
}
