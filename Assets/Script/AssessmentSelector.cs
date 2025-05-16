
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssessmentSelector : MonoBehaviour
{
    public void AR_Roomchat()
    {
        SceneManager.LoadScene("AR Room Chat");
    }

    // This method is called when the Mood Matching button is clicked
    public void Emotion_Detection()
    {
        SceneManager.LoadScene("Emotion Detection");
    }
}
