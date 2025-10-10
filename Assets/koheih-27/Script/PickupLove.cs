using UnityEngine;

/// <summary>
/// ƒvƒŒƒCƒ„[‚ªG‚ê‚½‚çÁ‚¦‚Ä LovePower ‚É•ñ‚·‚é
/// </summary>
public class PickupLove : MonoBehaviour
{
    [SerializeField]private LovePower manager;

    public void Steup(LovePower power) { manager = power; }

    private void Awake()
    {
        var col = GetComponent<Collider2D>();
        if(col == null) col = gameObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.CompareTag("Player")) return;

        if (manager != null)
            AudioManager.Instance.PlaySEById(SEName.GetItem);
            manager.OnPickupCollected(); // LovePower ‚É•ñ
            Destroy(gameObject);         // ©•ª‚ğÁ‚·
        
    }
}