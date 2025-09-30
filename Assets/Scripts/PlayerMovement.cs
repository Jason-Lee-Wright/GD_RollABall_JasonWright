using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;

    public float BPM = 114f;
    private float BeatInterval;
    private float SongPosition;

    public Slider BPMSlider;
    //If BPMSlider is offset CHECK THE SLIDER VALUES IN THE INSPECTOR

    private GameManager gameManager;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = FindAnyObjectByType<GameManager>();
        BPMSlider = Slider.FindAnyObjectByType<Slider>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        BeatInterval = 60f / BPM;
        SongPosition = 0f;
    }

    void Update()
    {
        SongPosition += Time.deltaTime;

        if (BPMSlider != null)
        {
            float beatProgress = (SongPosition % BeatInterval) / BeatInterval;
            BPMSlider.value = beatProgress;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        if (movementVector == Vector2.zero) return;

        float timeSinceLastBeat = SongPosition % BeatInterval;
        float distanceToBeat = Mathf.Min(timeSinceLastBeat, BeatInterval - timeSinceLastBeat);

        float closeness = 1f - (distanceToBeat / (BeatInterval / 2f));
        closeness = Mathf.Clamp01(closeness);

        Vector3 movement = new Vector3(movementVector.x, 0f, movementVector.y);
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


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}