using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject PlayerCamera;
    public float speed = 5f;

    public Slider BPMSlider;

    private GameManager gameManager;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = FindAnyObjectByType<GameManager>();
        BPMSlider = FindAnyObjectByType<Slider>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (BPMSlider != null)
            BPMSlider.value = GameTiming.BeatProgress;

        GameTiming.UpdateTiming();
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

    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
}