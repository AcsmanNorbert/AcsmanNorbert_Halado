using UnityEngine;


public class RangedTargetProvider : TargetProvider
{
    [SerializeField] float range = 2;

    Agent target;

    public override Agent GetTarget()
    {
        if (target != null && !IsInRange(target))
            target = null;

        if (target == null)
            target = FindClosestAgentInRange();

        return target;
    }

    Agent FindClosestAgentInRange()
    {
        Agent[] allAgents = FindObjectsOfType<Agent>();

        Vector3 p = transform.position;
        float minDistance = float.MaxValue;
        Agent closest = null;

        foreach (Agent agent in allAgents)
        {
            float distance = Vector3.Distance(agent.AimingPoint, p);
            if (distance > range) continue;
            if (distance > minDistance) continue;

            minDistance = distance;
            closest = agent;
        }

        return closest;
    }

    bool IsInRange(Agent agent)
    {
        Vector3 p = transform.position;
        float distance = Vector3.Distance(agent.AimingPoint, p);
        return distance <= range;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (target != null)
            Gizmos.DrawLine(target.AimingPoint, transform.position);
    }
}