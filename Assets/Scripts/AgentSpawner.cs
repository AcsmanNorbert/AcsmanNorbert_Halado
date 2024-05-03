using System.Collections;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] Wave wave;

    void Start()
    {
        StartCoroutine(SpawnAll());
    }

    IEnumerator SpawnAll()
    {
        yield return wave.StartWave(transform);
    }
}
