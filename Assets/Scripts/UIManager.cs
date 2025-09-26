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

        Debug.Log("Score" + ScoreCount);

        ScoreText.text = $"Score: {ScoreCount} / 12";

        if (ScoreCount >= 12)
        {
            WinState();
        }
    }

    void WinState()
    {
        WinText.gameObject.SetActive(true);
    }
}
