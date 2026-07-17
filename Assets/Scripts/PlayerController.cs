using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Rigidbody of player
    private Rigidbody rb;
    private int count;

    // Movement
    private float movementX;
    private float movementY;

    // Speed
    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)

    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }



    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
    }

    //Shiny counter
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            Audio.Instance.PlaySFX("PickUp");

        }

    }

    //when you collect all shinies
    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();


        if (count >= 24)
        {
            winTextObject.SetActive(true);
        }
    }

    //When Enemy hits Player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy Player
            Destroy(gameObject);
            //Update text to You Lose! and display it
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

}
