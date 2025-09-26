using TMPro;
using UnityEngine;

public class PickUpLogic : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void PickUpAction(GameObject HitObject)
    {
        Debug.Log("ActionCalled");

        if (HitObject.CompareTag("PickUp"))
        {
            Debug.Log("PickUpTagFound");
            PickUpPoint();
        }

        HitObject.SetActive(false);
    }

    void PickUpPoint()
    {
        gameManager.uiManager.ScoreIncrease();
    }
}
