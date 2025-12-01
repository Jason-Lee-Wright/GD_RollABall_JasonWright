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
            Debug.Log("DoingSOMETHING");
            effectedMaterial1.SetVector("_PlayerPosition", player.position);
            Debug.Log(player.position);
            effectedMaterial1.SetFloat("_RevealRadius", revealRadius);
        }

        if (player != null && effectedMaterial2 != null)
        {
            Debug.Log("DoingSOMETHING");
            effectedMaterial2.SetVector("_PlayerPosition", player.position);
            Debug.Log(player.position);
            effectedMaterial2.SetFloat("_RevealRadius", revealRadius);
        }

        if (player != null && effectedMaterial3 != null)
        {
            Debug.Log("DoingSOMETHING");
            effectedMaterial3.SetVector("_PlayerPosition", player.position);
            Debug.Log(player.position);
            effectedMaterial3.SetFloat("_RevealRadius", revealRadius);
        }

        if (player != null && effectedMaterial4 != null)
        {
            Debug.Log("DoingSOMETHING");
            effectedMaterial4.SetVector("_PlayerPosition", player.position);
            Debug.Log(player.position);
            effectedMaterial4.SetFloat("_RevealRadius", revealRadius);
        }
    }

    public void IncreaseRadius()
    {
        revealRadius = 1 * (10 * gameManager.uiManager.ScoreCount);
    }
}
