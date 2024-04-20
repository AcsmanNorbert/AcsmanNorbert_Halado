using UnityEngine;

public class PathWalker : Drawable
{
    [SerializeField] Vector3[] points;

    protected override Vector3[] GetPositions() => points;    
}
