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

    bool IsInRange(Agent target)
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

        if (target == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(myPos, target.transform.position);
    }
}
