using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField] float damageRate = 10;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField, Min(2)] int linePositionsAmount = 2;

    protected override void ChildUpdate()
    {        
        if (Target != null)        
            Target.Damage(damageRate * Time.deltaTime);
        
        UpdateLaserVisual();
    }

    private void UpdateLaserVisual()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        lineRenderer.enabled = Target != null;
        if (Target == null) return;

        lineRenderer.positionCount = linePositionsAmount;

        Vector3 myPos = transform.position;
        Vector3 targetPos = Target.AimingPoint;
        Vector3 step = (targetPos - myPos) / (linePositionsAmount - 1);

        lineRenderer.SetPosition(0, myPos);
        for (int i = 1; i < linePositionsAmount; i++)
            lineRenderer.SetPosition(i, myPos + step * i);
    }
}
