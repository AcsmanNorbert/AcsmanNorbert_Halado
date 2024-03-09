using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Agent agent;
    [SerializeField] Image healthImage;

    private void Awake()
    {
        agent.OnHealthCanged += OnUpdateHealthBar;
    }

    private void Update()
    {
        //billboarding
        transform.LookAt(Camera.main.transform.position);
    }

    public void OnUpdateHealthBar(float healthRate)
    {
        healthImage.fillAmount = healthRate;
    }

    private void OnDestroy()
    {
        agent.OnHealthCanged -= OnUpdateHealthBar;
    }
}
