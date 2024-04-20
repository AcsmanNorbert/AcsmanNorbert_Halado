using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistics : MonoBehaviour
{
    [SerializeField] Rigidbody projectilePrefab;

    [SerializeField] Transform target;
    [SerializeField] float trowingAngle = 45;
    //[SerializeField] Vector3 startVelocity;
    [SerializeField] float drawingTime;
    [SerializeField] float maxSpeed = 10;

    Vector3 GetStartVelocity()
    {
        Vector3 offset = target.position - transform.position;
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

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody currentProjectile = Instantiate(projectilePrefab);
            currentProjectile.position = transform.position;
            currentProjectile.velocity = GetStartVelocity();

            Destroy(currentProjectile.gameObject, drawingTime);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 point = transform.position;
        Vector3 velocity = GetStartVelocity();

        int pointCount = (int)(drawingTime / Time.fixedDeltaTime);
        float r = projectilePrefab.transform.localScale.x * 0.5f;

        List<Vector3> points = new(pointCount);

        for (int i = 0; i < pointCount; i++)
        {
            velocity += Physics.gravity * Time.fixedDeltaTime;

            Collider[] colliders = Physics.OverlapSphere(point, r);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out GravityModifier gm))
                    velocity += gm.Gravity * Time.fixedDeltaTime;
            }

            //velocity -= projectilePrefab.drag * Time.fixedDeltaTime * velocity;
            point += velocity * Time.fixedDeltaTime;
            points.Add(point);
        }

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }*/
}
