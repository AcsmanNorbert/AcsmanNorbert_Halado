using UnityEngine;

public class SpiralDrawer : Drawable
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius = 1;
    [SerializeField, Min(3)] int pointCount = 100;
    [SerializeField] float height;
    [SerializeField] float looping = 1;
    [SerializeField] bool closeLoop = true;

    protected override sealed Vector3[] GetPositions()
    {
        int count = closeLoop ? pointCount + 1 : pointCount;
        Vector3[] result = new Vector3[count];
        float deltaAngle = 2 * Mathf.PI / pointCount * looping;

        Vector3 offset = Vector3.forward * height / (count - 1);
        for (int i = 0; i < count; i++)
        {
            float angle = (i % count) * deltaAngle;
            result[i] = GetPoint(angle) + (offset * i);
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
