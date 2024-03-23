using UnityEngine;

public class PathWalker : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField] Transform movingObject;
    [SerializeField] float speed;
    [SerializeField] bool isLooping;

    private void Start()
    {
        movingObject.position = points[0];
    }

    Vector3 GetPoint(int index) => transform.TransformPoint(points[index]);

    int index = 0;
    bool moveForward = true;

    void Update()
    {
        Vector3 target = GetPoint(index);
        float step = speed * Time.deltaTime;
        movingObject.position = Vector3.MoveTowards(movingObject.position, target, step);

        if (movingObject.position == target)
        {
            if (!isLooping)
            {
                if((moveForward && index == points.Length-1) || (!moveForward && index == 0))
                    moveForward = !moveForward;

                index += moveForward ? 1 : -1;
            }
            else
                index = (index + 1) % points.Length;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (points == null) return;

        Gizmos.color = Color.blue;
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector3 p1 = GetPoint(i);
            Vector3 p2 = GetPoint(i + 1);
            Gizmos.DrawLine(p1,p2);
        }

        if(isLooping && points.Length >= 3)
            Gizmos.DrawLine(GetPoint(0), GetPoint(points.Length - 1));
    }
}
