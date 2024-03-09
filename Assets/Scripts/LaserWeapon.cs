using System;
using Unity.VisualScripting;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] float range = 2;
    [SerializeField] float damageRate = 10;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField, Min(2)] int linePositionsAmount = 2;

    Agent closest;

    void Update()
    {
        if (closest != null && !IsInRange(closest))
            closest = null;

        if (closest == null)
            closest = FindClosestAgentInRange();

        if (closest != null)        
            closest.Damage(damageRate * Time.deltaTime);
        
        UpdateLaserVisual();
    }

    private void UpdateLaserVisual()
    {
        lineRenderer.enabled = closest != null;
        if (closest == null) return;

        lineRenderer.positionCount = linePositionsAmount;

        Vector3 myPos = transform.position;
        Vector3 targetPos = closest.transform.position;
        Vector3 step = (targetPos - myPos) / linePositionsAmount;

        lineRenderer.SetPosition(0, myPos);
        for (int i = 1; i < linePositionsAmount; i++)
            lineRenderer.SetPosition(i, myPos + step * i);
    }

    private bool IsInRange(Agent target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        return distance <= range;
    }

    Agent FindClosestAgentInRange()
    {
        Agent[] agents = FindObjectsOfType<Agent>();
        if (agents.Length == 0) return null;

        Vector3 myPos = transform.position;

        Agent closestAgent = null;
        float closestAgentDistance = float.MaxValue;

        foreach (Agent agent in agents)
        {
            float currentAgentDistance = Vector3.Distance(myPos, agent.transform.position);
            if (currentAgentDistance > range) continue;
            if (currentAgentDistance >= closestAgentDistance) continue;

            closestAgent = agent;
            closestAgentDistance = currentAgentDistance;
        }
        return closestAgent;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 myPos = transform.position;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(myPos, range);

        if (closest == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(myPos, closest.transform.position);
    }
}
