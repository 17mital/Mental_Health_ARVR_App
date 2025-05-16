using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void GoBackToGameMenu()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoBackToAssessmentMenu()
    {
        SceneManager.LoadScene("AssessmentScene");
    }
    public void GoBackToCounsellingActivity()
    {
        SceneManager.LoadScene("Counselling_Activity");
    }
    public void GoBackToIntrolevel()
    {
        SceneManager.LoadScene("introLevel");
    }
}
