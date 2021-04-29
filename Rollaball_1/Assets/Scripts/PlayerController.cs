using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countTextGreen;
    public TextMeshProUGUI countTextRed;
    public GameObject redWinTextObject;
    public GameObject greenWinTextObject;
    public Light lt;

    private Rigidbody rb;
    private int countGreen;
    private int countRed;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countGreen = 0;
        countRed = 0;

        greenWinTextObject.SetActive(false);
        redWinTextObject.SetActive(false);
        SetCountTextGreen();
        SetCountTextRed();
    }

    void OnMove( InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountTextGreen()
    {
        countTextGreen.text = "Count: " + countGreen.ToString();
        if (countGreen >= 8 && countRed != 8)
        {
            greenWinTextObject.SetActive(true);
            lt.color = Color.green;
        }
    }

    void SetCountTextRed()
    {
        countTextRed.text = "Count: " + countRed.ToString();
        if (countRed >= 8 && countGreen != 8)
        {
            redWinTextObject.SetActive(true);
            lt.color = Color.red;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpGreen"))
        {
            other.gameObject.SetActive(false);
            countGreen = countGreen + 1;

            SetCountTextGreen();
        }
        if (other.gameObject.CompareTag("PickUpRed"))
        {
            other.gameObject.SetActive(false);
            countRed = countRed + 1;

            SetCountTextRed();
        }
    }
}
