using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "TowerDeffense/ComplexWave", order = 3)]
public class ComplexWave : Wave
{
    [SerializeField] Wave[] waves;
    [SerializeField] float delay;

    public override IEnumerator StartWave(Transform tower)
    {
        foreach (Wave wave in waves)
        {
            yield return new WaitForSeconds(delay);
            yield return wave.StartWave(tower);
        }
    }
}
