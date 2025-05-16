using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmotionUIManager : MonoBehaviour
{
    public EmotionSender emotionSender;
    public TMP_Text emotionText;

    public void OnDetectButtonPressed()
    {
        StartCoroutine(emotionSender.SendToPython(UpdateEmotionText));
    }

    void UpdateEmotionText(string emotion)
    {
        emotionText.text = "Detected Emotion: " + emotion;
    }
}
