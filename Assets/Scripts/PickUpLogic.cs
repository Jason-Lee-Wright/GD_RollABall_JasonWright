using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PickUpLogic : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Player;

    public List<GameObject> PickUpModel = new List<GameObject>();

    private List<GameObject> PickUpAmmount = new List<GameObject>();

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = FindAnyObjectByType<GameManager>();
        RandomizePickUpModels();
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

    void RandomizePickUpModels()
    {
        GameObject.FindGameObjectsWithTag("PickUp");

        foreach (GameObject pickup in PickUpModel)
        {
            Random.Range(0, PickUpModel.Count);
        }
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
