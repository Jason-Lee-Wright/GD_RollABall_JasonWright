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
}