using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SiralıYazma : MonoBehaviour
{
    private Text displayText; // UI Text bileşeni
    public string[] texts; // Yazılacak metinler
    public float typingSpeed = 0.05f; // Harf başına yazma hızı
    private int currentTextIndex = 0;
    private int isTypingDurum = 0;
    public GameObject[] activeGameObject;

    private void Start()
    {
        displayText = GetComponent<Text>();
        displayText.text = ""; // Başlangıçta metin alanını temizle
        StartTypingNextText();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {


            // Metin yazma işlemi devam ediyorsa herhangi bir tuşa basıldığında atla
            if (isTypingDurum == 1)
            {
                SkipTyping();
            }
            else if (isTypingDurum == 2)
            {
                isTypingDurum = 3;
                foreach (GameObject go in activeGameObject)
                {
                    go.SetActive(true);
                }
            }
            else if (isTypingDurum == 3)
            {
                LoadNextScene();
            }
        }
    }

    private void StartTypingNextText()
    {
        print(texts);
        if (currentTextIndex < texts.Length)
        {
            
            StartCoroutine(TypeText(texts[currentTextIndex]));
            currentTextIndex++;
        }
        else
        {
            isTypingDurum = 2;
            Debug.Log("Tüm metinler yazıldı.");
        }
    }

    private void SkipTyping()
    {
        StopAllCoroutines(); // Yazma işlemini durdur
        displayText.text = texts[currentTextIndex - 1]; // Tamamlanmış metni göster
        isTypingDurum = 0;
        Invoke("StartTypingNextText", 1.0f); // Bir saniye sonra bir sonraki metni yazmaya başla
    }

    private IEnumerator TypeText(string textToType)
    {
        isTypingDurum = 1;
        displayText.text = ""; // Metin alanını temizle

        foreach (char letter in textToType)
        {
            displayText.text += letter; // Harf harf metni ekle
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingDurum = 0;
        yield return new WaitForSeconds(1.0f); // Metni tamamlanınca bir saniye bekle
        StartTypingNextText(); // Bir sonraki metne geç
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Mevcut sahnenin index numarasını al
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Son sahneye ulaşıldı.");
        }
    }
}
