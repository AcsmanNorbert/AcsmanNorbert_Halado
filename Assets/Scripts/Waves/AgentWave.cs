using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDeffense/AgentWave", order = 1)]
public class AgentWave : Wave
{
    [SerializeField] GameObject agentPrefab;
    [SerializeField] int count;
    [SerializeField] float delay;

    public override IEnumerator StartWave(Transform tower)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(agentPrefab, tower.position, tower.rotation, tower);
        }
    }
}
