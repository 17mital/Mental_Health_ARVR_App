using UnityEngine;

public class ButtonMovementController : MonoBehaviour
{
    private ControleurJoueur playerController;

    void Start()
    {
        // Find the player script in the scene
        playerController = FindObjectOfType<ControleurJoueur>();
    }

    public void OnUpButton()
    {
        playerController.MoveInDirection(Vector3.forward);
    }

    public void OnDownButton()
    {
        playerController.MoveInDirection(Vector3.back);
    }

    public void OnLeftButton()
    {
        playerController.MoveInDirection(Vector3.left);
    }

    public void OnRightButton()
    {
        playerController.MoveInDirection(Vector3.right);
    }

    public void OnStop()
    {
        playerController.MoveInDirection(Vector3.zero);
    }
}
