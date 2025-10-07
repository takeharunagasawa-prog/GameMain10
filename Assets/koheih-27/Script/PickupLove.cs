using UnityEngine;

/// <summary>
/// プレイヤーが触れたら消えて LovePower に報告する
/// </summary>
public class PickupLove : MonoBehaviour
{
    private LovePower manager;

    // 呼び出し元（LovePower）を登録
    public void Setup(LovePower mgr)
    {
        manager = mgr;
        // Colliderがなければ自動で付ける
        var col = GetComponent<Collider2D>();
        if (col == null) col = gameObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.OnPickupCollected(); // LovePower に報告
            Destroy(gameObject);         // 自分を消す
        }
    }
}