using System;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PickUpLogic pickUpLogic;
    [HideInInspector] public UIManager uiManager;


    public void DontDestroy()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        uiManager = FindAnyObjectByType<UIManager>();
        pickUpLogic = FindAnyObjectByType<PickUpLogic>();
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