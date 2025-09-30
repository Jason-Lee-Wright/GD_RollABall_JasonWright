using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private bool CanPause = false;
    [SerializeField] private bool IsPaused = false;

    [SerializeField] private GameObject PauseMenu;


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");

        if (PauseMenu != null && scene.name == "MiniGame")
        {
            PauseMenu.SetActive(false);
        }

        if ( scene.name == "MiniGame")
        {
            CanPause = true;
        }
        else
        {
            CanPause = false;
        }
    }

    public void PlayB()
    {
        CanPause = true;
        PauseMenu.SetActive(true);
        SceneManager.LoadScene("MiniGame");
    }

    public void QuitB()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (CanPause && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                PauseMenu.SetActive(true);
                IsPaused = true;
                Time.timeScale = 0f;
            }
            else if (IsPaused)
            {
                PauseMenu.SetActive(false);
                IsPaused = false;
                Time.timeScale = 1f;
            }
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
