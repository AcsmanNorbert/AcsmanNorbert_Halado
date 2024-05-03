using System;
using System.Collections;
using UnityEngine;

[Serializable]
struct DelayedSpawn
{
    public GameObject prefab;
    public float delay;
}

[CreateAssetMenu(menuName = "TowerDeffense/SequenceWave", order = 2)]
public class SequenceWave : Wave
{
    [SerializeField] DelayedSpawn[] agents;

    public override IEnumerator StartWave(Transform tower)
    {
        foreach (DelayedSpawn spawn in agents)
        {
            yield return new WaitForSeconds(spawn.delay);
            Instantiate(spawn.prefab, tower.position, tower.rotation, tower);
        }
    }
}
