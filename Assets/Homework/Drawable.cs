using UnityEngine;

public abstract class Drawable : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float sizeMultiplier;
    [SerializeField] Space drawingSpace;

    [SerializeField] Transform movingObject;
    [SerializeField] float speed = 10;
    [SerializeField] bool isLooping;

    bool moveForward = true;
    int index = 0;

    void OnValidate()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        UpdateLinePoints();
    }

    void Start()
    {
        Vector3[] points = ModifyPositions();
        if (movingObject == null)
            Debug.Log("No object assgned to path: " + gameObject.name);
        else
            movingObject.position = points[0];
    }

    void Update()
    {
        UpdateLinePoints();
        if (movingObject == null) return;

        Vector3[] points = ModifyPositions();
        Vector3 target = points[index];
        float step = speed * Time.deltaTime;
        movingObject.position = Vector3.MoveTowards(movingObject.position, target, step);

        if (movingObject.position == target)
        {
            if (isLooping)
            {
                index = (index + 1) % points.Length;
            }
            else
            {
                if ((moveForward && index == points.Length - 1) || (!moveForward && index == 0))
                    moveForward = !moveForward;

                index += moveForward ? 1 : -1;
            }
        }
    }

    public void UpdateLinePoints()
    {
        if (lineRenderer == null) return;
        Vector3[] points = ModifyPositions();
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }

    protected abstract Vector3[] GetPositions();
    protected Vector3[] ModifyPositions()
    {
        Vector3[] points = GetPositions();
        Vector3[] modified = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 point = points[i];
            point *= sizeMultiplier;

            if (drawingSpace == Space.Self)
                point = transform.TransformPoint(point);

            modified[i] = point;
        }
        return modified;
    }

    void OnDrawGizmosSelected()
    {
        Vector3[] points = ModifyPositions();

        for (int i = 0; i < points.Length - 1; i++)
        {
            int i2 = i + 1;
            Vector3 p1 = points[i];
            Vector3 p2 = points[i2];
            Gizmos.DrawLine(p1, p2);
        }
    }
}