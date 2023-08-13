using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        GameObject desDont = GameObject.Find("dontDestroy");
        text.text = "En yüksek skor : " + desDont.GetComponent<DontDestroy>().puanMax.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LoadBackScene();
    }
    public void LoadBackScene()
    {
        SceneManager.LoadScene(0);
    }
}
