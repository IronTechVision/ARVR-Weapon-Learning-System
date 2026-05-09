using UnityEngine;
using System.Diagnostics;

public class JEMYVoice : MonoBehaviour
{
    public static JEMYVoice instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Speak(string text)
    {
        if (string.IsNullOrEmpty(text)) return;

        // 🔥 Clean text
        text = text.Replace("\n", " ").Replace("\r", " ");
        text = text.Replace("\"", "").Replace("'", "");

        // 🔊 PowerShell TTS (Windows)
        string command = $@"
Add-Type -AssemblyName System.Speech;
$speak = New-Object System.Speech.Synthesis.SpeechSynthesizer;

# Try female voice
try {{
    $speak.SelectVoice('Microsoft Zira Desktop');
}} catch {{}}

$speak.Rate = -1;
$speak.Volume = 100;

$speak.Speak('{text}');
";

        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "powershell.exe";
        psi.Arguments = "-NoProfile -Command \"" + command + "\"";
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;

        Process.Start(psi);
    }
}