using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private bool CanPause = false;
    [SerializeField] private bool IsPaused = false;

    public GameObject PauseMenu;
    public GameManager gameManager;

    private void Update()
    {
        if (PauseMenu != null)
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

    }

    public void PlayB()
    {
        CanPause = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MiniGame");
    }

    public void QuitB()
    {
        Application.Quit();
    }

    public void MainMenuB()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainMenu");
    }
}
