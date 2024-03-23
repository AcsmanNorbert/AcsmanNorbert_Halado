using UnityEngine;

public class CircleDrawer : Drawable
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius = 1;
    [SerializeField, Min(3)] int pointCount = 100;
    [SerializeField] bool closeCircle = true;

    protected override Vector3[] GetPositions()
    {
        int count = closeCircle ? pointCount + 1 : pointCount;
        Vector3[] result = new Vector3[count];
        float deltaAngle = 2 * Mathf.PI / pointCount ;

        for (int i = 0; i < count; i++)
        {
            float angle = (i % count) * deltaAngle;
            result[i] = GetPoint(angle);
        }

        return result;
    }

    Vector3 GetPoint(float angle)
    {
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        return (new Vector3(x, y) * radius) + center;
    }
}
