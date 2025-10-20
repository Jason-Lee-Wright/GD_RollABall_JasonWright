using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText, WinText;

    private int ScoreCount = 0;

    private void Start()
    {
        WinText.gameObject.SetActive(false);
    }

    public void ScoreIncrease()
    {
        ScoreCount++;

        ScoreText.text = $"Score: {ScoreCount} / 12";

        if (ScoreCount >= 12)
        {
            Win_Lose("You Win!");
            WinState();
        }
    }

    public void Win_Lose(string Message)
    {
        WinText.text = Message;
    }

    void WinState()
    {
        WinText.gameObject.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        Time.timeScale = 0.0f;
    }

    public void LoseState()
    {
        WinText.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
