using TMPro;
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text infoText;

    public float typingSpeed = 0.02f; // adjust speed

    Coroutine typingRoutine;

    void Awake()
    {
        instance = this;

        if (infoText != null)
            infoText.text = "";
    }

    public void ShowTalkingText(string text)
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        typingRoutine = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        infoText.text = "";

        foreach (char c in text)
        {
            infoText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}