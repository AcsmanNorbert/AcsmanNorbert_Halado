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
            lastFireTime = Time.time;
        }
    }

    protected abstract void Fire();
}
