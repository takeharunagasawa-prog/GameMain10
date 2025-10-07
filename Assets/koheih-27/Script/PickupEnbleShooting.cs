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
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (consumed) return;
        if (!other.CompareTag(targetTag)) return;

        // プレイヤー側の射撃コンポーネントを取得（子コライダー対策で親も見る）
        var shooterDual = other.GetComponentInParent<PlayerShooterDual>();
        var shooterSimple = other.GetComponentInParent<PlayerShooterDual>();

        if (shooterDual != null) shooterDual.canShoot = true;
        if (shooterSimple != null) shooterSimple.canShoot = true;

        consumed = true;
        Destroy(gameObject); // 1回で消える
    }
}