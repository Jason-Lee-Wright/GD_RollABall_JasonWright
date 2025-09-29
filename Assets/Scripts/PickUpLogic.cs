using TMPro;
using UnityEngine;

public class PickUpLogic : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Player;
    private void Start()
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
}
