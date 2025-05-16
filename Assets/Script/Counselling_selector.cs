
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counselling_selector : MonoBehaviour
{
    public void Meditation_Room()
    {
        SceneManager.LoadScene("MeditationScene");
    }

    // This method is called when the Mood Matching button is clicked
    public void Virtual_Garden()
    {
        SceneManager.LoadScene("Virtual_Garden");
    }
    public void Physical_Trainer()
    {
        SceneManager.LoadScene("Physical_Trainer");
    }
}
