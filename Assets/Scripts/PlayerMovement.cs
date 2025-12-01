using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject PlayerCamera;
    public float speed = 8f;
    public float MaxVelosity = 5f;

    public Slider BPMSlider;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BPMSlider = FindAnyObjectByType<Slider>();
    }

    void Update()
    {
        if (BPMSlider != null)
            BPMSlider.value = GameTiming.BeatProgress;

        GameTiming.UpdateTiming();

        if (rb.linearVelocity.sqrMagnitude > MaxVelosity)
        {
            rb.linearVelocity *= 0.999f;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector3 CameraForward = PlayerCamera.transform.forward;
        Vector3 CameraRight = PlayerCamera.transform.right;

        CameraForward.y = 0;
        CameraRight.y = 0;

        CameraForward.Normalize();
        CameraRight.Normalize();

        Vector2 movementVector = movementValue.Get<Vector2>();
        if (movementVector == Vector2.zero) return;

        float closeness = GameTiming.GetClosenessToBeat();

        Vector3 movement = (CameraRight * movementVector.x) + (CameraForward * movementVector.y);
        rb.linearVelocity = movement.normalized * speed * closeness;
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