using UnityEngine;

public class BallisticProjectile : Projectile
{
    [SerializeField] Rigidbody rb;

    public override void Setup(LauncherWeapon launcher)
    {
        Aimer aimer = launcher.GetComponent<Aimer>();
        Agent target = launcher.GetComponent<TargetProvider>().GetTarget();

        Vector3 velocity = aimer.GetDirection(target);
        rb.velocity = velocity;
        rb.rotation = Quaternion.LookRotation(velocity);
        rb.position = aimer.StartPoint;
    }

    private void Update()
    {
        rb.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
