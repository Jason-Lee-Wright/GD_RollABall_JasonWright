using UnityEngine;
using UnityEngine.AI;

public class EnemyTeleport : MonoBehaviour
{
    public Transform player;
    public float maxStepDistance = 2f;

    private NavMeshPath path;

    void OnEnable()
    {
        TimingEvents.OnPulse += DoTeleport;
        path = new NavMeshPath();
    }

    void OnDisable()
    {
        TimingEvents.OnPulse -= DoTeleport;
    }

    int Delay = 0;

    void DoTeleport()
    {
        if (player == null) return;

        Delay++;

        if (NavMesh.CalculatePath(transform.position, player.position, NavMesh.AllAreas, path) && Delay == 2)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            bool Divided = false;

            if (distance < maxStepDistance)
            {
                maxStepDistance = maxStepDistance / 1.5f;
                Divided = true;
            }

            if (path.corners.Length > 1)
            {
                Vector3 nextPoint = path.corners[1];

                Vector3 dir = (nextPoint - transform.position).normalized;
                Vector3 teleportTo = transform.position + dir * maxStepDistance;

                transform.position = teleportTo;

                Delay = 0;
            }

            if (Divided) maxStepDistance = maxStepDistance * 1.5f;
        }
    }
}