using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Wave Name")]
public abstract class Wave : ScriptableObject
{
    public abstract IEnumerator StartWave(Transform tower);
}
