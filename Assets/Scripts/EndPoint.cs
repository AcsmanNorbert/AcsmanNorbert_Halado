using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Agent agent)) return;

        agent.OnHitEndpoint();

    }
}
