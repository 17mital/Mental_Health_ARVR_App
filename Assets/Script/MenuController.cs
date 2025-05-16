using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with your game scene name
    }

    public void StartAssessment()
    {
        SceneManager.LoadScene("AssessmentScene"); // Replace with your assessment scene
    }

    public void OpenCounseling()
    {
        SceneManager.LoadScene("Counselling_Activity"); // You can replace with your counseling resource
    }
}
