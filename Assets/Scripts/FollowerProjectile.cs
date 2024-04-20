using UnityEngine;

public class FollowerProjectile : Projectile
{
    [SerializeField] float damage = 10;
    [SerializeField] float speed = 10;
    [SerializeField] Elemental elemental;

    Agent target;

    public override void Setup(LauncherWeapon launcher)
    {
        Aimer aimer = launcher.GetComponent<Aimer>();
        target = launcher.GetComponent<TargetProvider>().GetTarget();
        transform.position = aimer.StartPoint;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;   
        }

        Vector3 targetPosition = target.AimingPoint;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            target.Damage(damage, elemental);
            Destroy(gameObject);
        }
    }
}
