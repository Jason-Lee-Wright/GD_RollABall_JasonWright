using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool CanPause = false;
    private bool IsPaused = false;

    private GameObject PauseMenu;


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PauseMenu = GameObject.Find("PauseMenu");
    }

    public void PlayB()
    {
        CanPause = true;
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
