using UnityEngine;

public class LauncherWeapon : PeriodicWeapon
{
    [SerializeField] Projectile projectilePrefab;

    protected override void Fire()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);

        projectile.Setup(Target);
    }
}
