using UnityEngine;

public class ModifiedSpiralDrawer : SpiralDrawer 
{
    //[SerializeField] float positionMultiplier = 1.1f;

    //cant inherit caused its sealed
    /*protected override Vector3[] GetPositions()
    {
        Vector3[] points = base.GetPositions();

        for (int i = 0; i < points.Length; i++)
            points[i] *= positionMultiplier;

        return points;
    }*/
}
