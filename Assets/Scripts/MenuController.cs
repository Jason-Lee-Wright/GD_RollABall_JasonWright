using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private bool CanPause = true;
    [SerializeField] private bool IsPaused = false;

    public GameObject PauseMenu, TutorialScreen;
    public GameManager gameManager;

    private void Start()
    {
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
            CanPause = true;
            IsPaused = false;
        }
    }

    private void Update()
    {
        // Escape = toggle pause
        if (PauseMenu != null && CanPause && Input.GetKeyDown(KeyCode.Escape))
        {
            bool pauseMenuActive = PauseMenu.activeSelf;

            if (pauseMenuActive)
            {
                PauseMenu.SetActive(false);
                ChangeTimeScale(true, "Pause");
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                PauseMenu.SetActive(true);
                ChangeTimeScale(false, "Pause");
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (TutorialScreen != null && Input.GetKeyDown(KeyCode.T))
        {
            bool tutorialActive = TutorialScreen.activeSelf;

            if (tutorialActive)
            {
                TutorialScreen.SetActive(false);
                ChangeTimeScale(true, "Tips");
            }
            else
            {
                TutorialScreen.SetActive(true);
                ChangeTimeScale(false, "Tips");
            }
        }
    }

    void ChangeTimeScale(bool resumeGame, string menu)
    {
        if (menu == "Pause")
        {
            if (resumeGame)
                IsPaused = false;
            else
                IsPaused = true;
        }

        bool anyMenuOpen = (PauseMenu.activeSelf || TutorialScreen.activeSelf);

        if (anyMenuOpen)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void PlayB()
    {
        CanPause = true;
        Time.timeScale = 0f;
        GameTiming.StartTiming();
        SceneManager.LoadScene("MiniGame");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitB()
    {
        Application.Quit();
    }

    public void RestartB()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void MainMenuB()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainMenu");
    }
}
