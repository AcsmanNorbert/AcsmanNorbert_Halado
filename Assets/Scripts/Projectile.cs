using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] float speed = 10;
    [SerializeField] Elemental elemental;

    Agent target;

    public void Setup(Agent target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;   
        }

        Vector3 targetPosition = target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            target.Damage(damage, elemental);
            Destroy(gameObject);
        }
    }
}
