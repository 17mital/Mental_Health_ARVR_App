using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class GameSelector : MonoBehaviour
{
    // This method is called when the Affirmation Catcher button is clicked
    public void PlayInfiniteRunner()
    {
        SceneManager.LoadScene("straightPathsLevel");
    }

    // This method is called when the Mood Matching button is clicked
    public void BallGame()
    {
        SceneManager.LoadScene("JeuBalles");
    }

    
}
