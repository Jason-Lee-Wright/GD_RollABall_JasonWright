using UnityEngine;

public class ProximityColorManager : MonoBehaviour
{
    public Transform player;
    public Material effectedMaterial1, effectedMaterial2, effectedMaterial3, effectedMaterial4;
    public float revealRadius = 1f;

    public GameManager gameManager;

    void Update()
    {
        if (player != null && effectedMaterial1 != null)
        {
            effectedMaterial1.SetVector("_PlayerPosition", player.position);
            effectedMaterial1.SetFloat("_RevealRadius", revealRadius);
        }

        if (player != null && effectedMaterial2 != null)
        {
            effectedMaterial2.SetVector("_PlayerPosition", player.position);
            effectedMaterial2.SetFloat("_RevealRadius", revealRadius);
        }

        if (player != null && effectedMaterial3 != null)
        {
            effectedMaterial3.SetVector("_PlayerPosition", player.position);
            effectedMaterial3.SetFloat("_RevealRadius", revealRadius);
        }

        if (player != null && effectedMaterial4 != null)
        {
            effectedMaterial4.SetVector("_PlayerPosition", player.position);
            effectedMaterial4.SetFloat("_RevealRadius", revealRadius);
        }
    }

    public void IncreaseRadius()
    {
        revealRadius = 1 * (10 * gameManager.uiManager.ScoreCount);
    }
}
