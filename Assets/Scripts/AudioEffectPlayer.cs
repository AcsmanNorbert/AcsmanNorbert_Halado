using UnityEngine;

public class AudioEffectPlayer : MonoBehaviour, IWeaponEffect
{
    [SerializeField] AudioSource source;
    [SerializeField] WeaponEvent effectTpye;

    public void DoEffect(WeaponEvent weaponEvent)
    {
        if(weaponEvent == effectTpye)
            source.Play();
    }
}
