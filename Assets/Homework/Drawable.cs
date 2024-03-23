using UnityEngine;

public abstract class Drawable : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Color gizmoColor = Color.blue;

    [SerializeField] float sizeMultiplier;

    void OnValidate()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        UpdateLinePoints();
    }

    void Start()
    {
        UpdateLinePoints();
    }

    public void UpdateLinePoints()
    {
        if (lineRenderer == null) return;
        Vector3[] points = GetPositions();
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }

    protected abstract Vector3[] GetPositions();


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Vector3[] positions = GetPositions();
        for (int i = 0; i < positions.Length - 1; i++)
        {
            Vector3 currentPoint = positions[i];
            Vector3 nextPoint = positions[i + 1];
            Gizmos.DrawLine(currentPoint, nextPoint);
        }
    }
}