using UnityEngine;

public class AutoDamageWeapon : PeriodicWeapon
{
    [SerializeField] float damage;

    protected override void Fire() => Target.Damage(damage);
}
