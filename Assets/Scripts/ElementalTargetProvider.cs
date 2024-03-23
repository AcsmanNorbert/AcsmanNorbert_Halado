using UnityEngine;

public class ElementalTargetProvider : TargetProvider
{
    [SerializeField] Elemental elemental;

    Agent target;

    public override Agent GetTarget()
    {
        foreach (Agent agent in FindObjectsOfType<Agent>())
        {
            if (!agent.isImmune(elemental))
            {
                target = agent;
                return agent;
            }
        }

        return null;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 myPos = transform.position;

        if (target == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(myPos, target.transform.position);
    }
}
