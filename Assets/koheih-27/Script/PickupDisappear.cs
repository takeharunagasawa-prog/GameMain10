using UnityEngine;

/// <summary>
/// プレイヤーが触れたら消えるアイテム
/// （Pickup側にアタッチ）
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class PickupDisappear : MonoBehaviour
{
    [Header("拾える対象のタグ（例: Player）")]
    public string targetTag = "Player";

    void Awake()
    {
        // 安全設定（衝突で押されないように）
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        // Trigger にしておく
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    // Playerが触れたら消す
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("PlayerがPickupに触れました！");
            Destroy(gameObject);
        }
    }
}

