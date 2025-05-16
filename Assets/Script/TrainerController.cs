using System.Collections;
using UnityEngine;

public class TrainerController : MonoBehaviour
{
    public Animator trainerAnimator;
    public AudioSource audioSource;
    public AudioClip exerciseClip;

    private bool isPlaying = false;
    private Coroutine workoutRoutine;

    private float timePerExercise = 5f;

    public void StartExercise()
    {
        if (isPlaying) return;

        isPlaying = true;

        // Play audio
        if (exerciseClip != null)
        {
            audioSource.clip = exerciseClip;
            audioSource.loop = true;
            audioSource.Play();
        }

        // Start animation routine
        workoutRoutine = StartCoroutine(ExerciseLoop());
    }

    public void StopExercise()
    {
        isPlaying = false;

        // Stop the exercise loop (if it exists)
        if (workoutRoutine != null)
            StopCoroutine(workoutRoutine);

        // Ensure the Animator is in the Idle state, targeting the first layer (index 0)
        trainerAnimator.Play("Idle", 0, 0f);

        // Reset the triggers to prevent any further transitions
        trainerAnimator.ResetTrigger("DoSquat");
        trainerAnimator.ResetTrigger("DoSitup");

        // Stop the audio if it's playing
        if (audioSource.isPlaying)
            audioSource.Stop();
    }



    private IEnumerator ExerciseLoop()
    {
        while (isPlaying)
        {
            // Trigger Air Squat
            trainerAnimator.SetTrigger("DoSquat");
            yield return new WaitForSeconds(timePerExercise);

            // Trigger Situp
            trainerAnimator.SetTrigger("DoSitup");
            yield return new WaitForSeconds(timePerExercise);
        }
    }
}
