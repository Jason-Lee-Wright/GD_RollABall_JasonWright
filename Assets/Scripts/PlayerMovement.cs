using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;

    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.pickUpLogic.PickUpAction(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.pickUpLogic.PickUpAction(collision.gameObject);
    }
}

//Rythym based movemenr. have a bar that scales from 0-1, and mulitplys the movement force alone with how close you are to the beat.