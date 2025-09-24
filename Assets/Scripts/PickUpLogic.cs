using TMPro;
using UnityEngine;

public class PickUpLogic : MonoBehaviour
{
    public TextMeshProUGUI Score;

    private int ScoreCount = 0;

    public void PickUpAction(GameObject HitObject)
    {
        Debug.Log("ActionCalled");

        if (HitObject.CompareTag("PickUp"))
        {
            Debug.Log("PickUpTagFound");
            PickUpPoint();
        }

        HitObject.SetActive(false);
    }

    void PickUpPoint()
    {
        ScoreCount++;

        Debug.Log("Score" +  ScoreCount);

        //Score.text = $"Score: {ScoreCount}";
    }
}
