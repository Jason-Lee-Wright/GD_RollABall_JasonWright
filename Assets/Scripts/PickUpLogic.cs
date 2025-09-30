using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpLogic : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Player;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void PickUpAction(GameObject HitObject)
    {
        if (HitObject.CompareTag("PickUp"))
        {
            PickUpPoint();

            HitObject.SetActive(false);
        }

        if (HitObject.CompareTag("Enemy"))
        {
            EnemyHit();
        }
    }

    void PickUpPoint()
    {
        gameManager.uiManager.ScoreIncrease();
    }

    void EnemyHit()
    {
        gameManager.uiManager.Win_Lose("You Lose");
        gameManager.uiManager.LoseState();
        Destroy(Player);
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
