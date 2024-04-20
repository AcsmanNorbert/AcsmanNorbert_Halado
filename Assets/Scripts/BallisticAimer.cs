using UnityEngine;

public class BallisticAimer : Aimer
{
    [SerializeField] Rigidbody projectilePrefab;

    [SerializeField] float trowingAngle = 45;
    [SerializeField] float maxSpeed = 10;

    public override Vector3 GetDirection(Agent target)
    {
        Vector3 offset = target.AimingPoint - transform.position;
        float y = offset.y;
        float x = (new Vector2(offset.x, offset.z)).magnitude;
        float g = -Physics.gravity.y;
        float a = trowingAngle * Mathf.Deg2Rad;

        float m = g * x * x;
        float cosASq = Mathf.Pow(Mathf.Cos(a), 2);
        float n = 2 * cosASq * (x * Mathf.Tan(a) - y);
        float v = Mathf.Sqrt(m / n);

        v = Mathf.Min(v, maxSpeed);

        Vector2 dir2D = new Vector2(Mathf.Cos(a), Mathf.Sin(a)) * v;
        offset.y = 0;
        offset.Normalize();

        Vector3 dir3D = new(dir2D.x * offset.x, dir2D.y, dir2D.x * offset.z);
        return dir3D;
    }
}
