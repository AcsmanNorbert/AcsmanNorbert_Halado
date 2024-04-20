using UnityEngine;

public class DirectionalAimer : Aimer
{
    public override Vector3 GetDirection(Agent target) => target.AimingPoint - StartPoint;    
}
