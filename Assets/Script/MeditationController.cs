using UnityEngine;
using UnityEngine.UI;

public class MeditationController : MonoBehaviour
{
    public Light meditationLight;
    public AudioSource meditationSound;
    public Button startButton;
    public Button stopButton;

    void Start()
    {
        meditationLight.intensity = 0f;
        meditationSound.Stop();

        startButton.onClick.AddListener(StartMeditation);
        stopButton.onClick.AddListener(StopMeditation);
    }

    void StartMeditation()
    {
        meditationLight.intensity = 2f; // Turn ON spotlight
        meditationSound.Play();
    }

    void StopMeditation()
    {
        meditationLight.intensity = 0f; // Turn OFF spotlight
        meditationSound.Stop();
    }
}
