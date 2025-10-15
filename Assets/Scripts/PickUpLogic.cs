using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class PickUpLogic : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Player;

    public List<Mesh> PickUpModel = new List<Mesh>();

    private List<GameObject> PickUpAmount = new List<GameObject>();

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
        PickUpAmount.AddRange(GameObject.FindGameObjectsWithTag("PickUp"));

        foreach (GameObject pickup in PickUpAmount)
        {
            MeshFilter meshFilter = pickup.GetComponent<MeshFilter>();
            
            int RND = Random.Range(0, PickUpModel.Count);

            meshFilter.mesh = PickUpModel[RND];
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
