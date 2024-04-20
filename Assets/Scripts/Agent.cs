using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;
    [SerializeField] float startHealth = 100;
    [SerializeField] int moneyReward = 10;
    [SerializeField] int damage = 1;
    [SerializeField] Elemental[] immunities;
    [SerializeField] Vector3 localAimingPoint;

    static List<Agent> agents = new();
    public static IReadOnlyList<Agent> Agents => agents;

    void OnEnable() => agents.Add(this);
    void OnDisable() => agents.Remove(this);

    float health;

    public Action<float> OnHealthCanged;

    public Vector3 AimingPoint => transform.TransformPoint(localAimingPoint);

    public float GetHealthRate
    {
        get => health / startHealth;
        set => health = value * startHealth;
    }

    private void OnValidate()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        EndPoint ep = FindObjectOfType<EndPoint>();
        navMeshAgent.destination = ep.transform.position;
        GetHealthRate = 1;
        OnHealthCanged?.Invoke(GetHealthRate);
    }

    public void OnHitEndpoint()
    {
        GameManager.i.Damage(damage);
        Destroy(gameObject);
    }

    /*
    public void Damage(float damage, string elemental)
    {
        if (immunities.Contains(elemental)) return;
        Damage(damage);
    }*/

    public void Damage(float damage, Elemental elemental = Elemental.Non)
    {
        if (immunities != null && immunities.Contains(elemental)) return;

        health -= damage;

        OnHealthCanged?.Invoke(GetHealthRate);
        if (health <= 0)
        {
            GameManager.i.Money += moneyReward;
            //Debug.Log("Agent Died!");
            Destroy(gameObject);
        }
    }

    internal bool isImmune(Elemental elemental) => immunities.Contains(elemental);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AimingPoint, 0.15f);
    }
}
