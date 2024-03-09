using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;
    [SerializeField] float startHealth = 100;
    [SerializeField] int moneyReward = 10;
    [SerializeField] int damage = 1;

    float health;

    public Action<float> OnHealthCanged;

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

    public void Damage(float damage)
    {
        health -= damage;
        OnHealthCanged?.Invoke(GetHealthRate);
        if (health <= 0)
        {
            GameManager.i.Money += moneyReward;
            //Debug.Log("Agent Died!");
            Destroy(gameObject);
        }
    }
}
