using System;
using UnityEngine;

public abstract class PeriodicWeapon : Weapon
{
    [SerializeField] float fireRate = 1;

    float lastFireTime;
    protected override void ChildUpdate()
    {
        if (Target == null) return;

        if (Time.time - lastFireTime >= (1 / fireRate))
        {
            Fire();
            PlayEffect(WeaponEvent.Shoot);

            lastFireTime = Time.time;
        }
    }

    public void PlayEffect(WeaponEvent weaponEvent)
    {
        IWeaponEffect[] allEffectPlayer = GetComponentsInChildren<IWeaponEffect>();
        foreach (IWeaponEffect player in allEffectPlayer)
            player.DoEffect(weaponEvent);
    }

    protected abstract void Fire();
}
