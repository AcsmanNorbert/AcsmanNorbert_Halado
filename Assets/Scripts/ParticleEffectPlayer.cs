using UnityEngine;

public class ParticleEffectPlayer : MonoBehaviour, IWeaponEffect
{
    [SerializeField] ParticleSystem particleSys;
    [SerializeField] WeaponEvent effectType;

    public void DoEffect(WeaponEvent weaponEvent)
    {
        if (weaponEvent == effectType)
            particleSys.Play();
    }
}
