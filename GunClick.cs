using UnityEngine;

public class GunClick : MonoBehaviour
{
    [Header("Gun Part Info")]
    public string partName;

    [TextArea(3, 10)]
    public string description;

    void OnMouseDown()
    {
        Debug.Log("Clicked: " + partName);

        // 🔹 Show UI text
        if (UIManager.instance != null)
        {
            UIManager.instance.ShowTalkingText(description);
        }
        else
        {
            Debug.LogWarning("UIManager not found!");
        }

        // 🔹 Speak using Windows voice (JEMYVoice)
        if (JEMYVoice.instance != null)
        {
            // 🔥 Clean text before speaking
            string cleanText = description
                .Replace("\n", " ")
                .Replace("\r", " ");

            JEMYVoice.instance.Speak(cleanText);
        }
        else
        {
            Debug.LogWarning("JEMYVoice not found in scene!");
        }
    }
}