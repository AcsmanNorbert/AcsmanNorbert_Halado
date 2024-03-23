using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] TargetProvider targetProvider;

    protected Agent Target => targetProvider.GetTarget();

    private void OnValidate()
    {
        if (targetProvider == null)
            targetProvider = GetComponent<TargetProvider>();
    }

    void Update()
    {
        ChildUpdate();
    }

    protected virtual void ChildUpdate() { }
    
}
