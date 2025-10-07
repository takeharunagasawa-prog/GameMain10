using UnityEngine;

/// <summary>
/// プレイヤーが触れたら「撃てるようになる」アイテム
/// ・アイテム側のCollider2Dは isTrigger = ON にする
/// ・Rigidbody2D を付けるなら Kinematic / Gravity 0 / 回転固定
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class PickupEnableShooting : MonoBehaviour
{
    [Header("拾える対象のタグ（Player など）")]
    public string targetTag = "Player";

    private bool consumed = false; // 多重取得の防止

    void Awake()
    {
        // Rigidbody2D がある場合、安全設定に変更
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        // Collider2Dをトリガー化（ぶつからないように）
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (consumed) return;
        if (!other.CompareTag(targetTag)) return;

        // プレイヤー側の射撃コンポーネントを取得（どちらでも対応）
        var shooterDual = other.GetComponentInParent<PlayerShooterDual>();
        var shooterSimple = other.GetComponentInParent<PlayerShooterSimple>();

        if (shooterDual != null) shooterDual.canShoot = true;
        if (shooterSimple != null) shooterSimple.canShoot = true;

        // 拾ったら即消す
        consumed = true;
        Destroy(gameObject);
    }
}

internal class PlayerShooterSimple
{
    internal bool canShoot;
}