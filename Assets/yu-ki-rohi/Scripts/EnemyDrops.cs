using UnityEngine;

public class EnemyDrops : MonoBehaviour, ICoreChargable
{
    private Transform coreTransform;
    [SerializeField] GameObject dropItemParticleSystem;

    void Start()
    {
        EnemyDropParticle.Instantiate(dropItemParticleSystem, transform.position, coreTransform, this);
    }

    public void ChargeExecute()
    {
        Debug.Log("ChargeExecute()");
    }

    public void SetTarget(Transform target)
    {
        coreTransform = target;
    }
}
