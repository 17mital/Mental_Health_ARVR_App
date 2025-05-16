using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleurJoueur : MonoBehaviour
{
    public float vitesse;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    private Vector3 buttonDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 keyboardInput = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 finalMove = keyboardInput + buttonDirection;

        rb.AddForce(finalMove * vitesse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cible"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }
    public void MoveInDirection(Vector3 dir)
    {
        buttonDirection = dir;
    }

    // These functions will be called by buttons

}
