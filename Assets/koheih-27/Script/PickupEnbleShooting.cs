using UnityEngine;

/// <summary>
/// プレイヤーが触れたら「撃てるようになる」アイテム
/// ・アイテム側のCollider2Dは isTrigger = ON にする
/// ・Playerには PlayerShooterSimple が付いている前提
/// </summary>
public class PickupEnableShooting : MonoBehaviour
{
    [Header("拾える対象のタグ（Playerなど）")]
    public string targetTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;

        // プレイヤーに付いている Shooter を探す
        PlayerShooter shooter = other.GetComponent<PlayerShooter>();
        if (shooter != null)
        {
            shooter.canShoot = true; // 撃てるようにする！
        }

        // 1回で消える
        Destroy(gameObject);
    }
}
