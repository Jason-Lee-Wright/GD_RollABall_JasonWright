using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class PickUpLogic : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Player;

    public List<GameObject> PickUpModel = new List<GameObject>();

    private List<GameObject> PickUpAmount = new List<GameObject>();

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if (scene == SceneManager.GetSceneByName("MiniGame"))
        {
            RandomizePickUpModels();
        }
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

            Transform newParent = pickup.transform;

            GameObject originalPrefab = PickUpModel[RND];

            GameObject newObject = Instantiate(originalPrefab, newParent);
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
