using System.Collections;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] Agent[] agentPrefabs;
    [SerializeField] int count;
    [SerializeField] float duration = 1;

    void Start()
    {
        StartCoroutine(SpawnAll());
    }

    IEnumerator SpawnAll()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(duration);
            Spawn();
        }
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, agentPrefabs.Length);
        Agent agentPrefab = agentPrefabs[randomIndex];
        Agent agent = Instantiate(agentPrefab, transform.position, transform.rotation, transform);    
    }
}
