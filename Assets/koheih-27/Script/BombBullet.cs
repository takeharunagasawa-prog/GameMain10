using System;
using UnityEngine;

/// <summary>
/// まっすぐ飛ぶ弾。lifeTime 秒で自動爆発。
/// ぶつかった時も爆発する。
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class BombBullet : MonoBehaviour
{
    
    [Header("弾の速さ")]
    [SerializeField]
    public float speed = 8f;

    [Header("何秒で自動爆発するか")]
    [SerializeField]
    public float lifeTime = 1.2f;

    [Header("爆発の見た目（SimpleExplosion を付けた物）")]
    public GameObject explosionPrefab;

    [Header("この矢が狙う相手のタグ（例：Enemy）")]
    public string targetTag = "Enemy";

    // PlayerShooter から渡される「進む向き」
    [HideInInspector] public Vector2 moveDir = Vector2.right;

    float timer = 0f;

    // 発射主(プレイヤー)を覚える
    Transform owner;
    Collider2D myCol;

    public void SetOwner(Transform t)
    {
        owner = t;

        if(myCol == null) myCol = GetComponent<Collider2D>();
        if(myCol != null && owner != null)
        {
            foreach (var c in owner.GetComponentsInChildren<Collider2D>())
                Physics2D.IgnoreCollision(myCol, c, true);
        }
    }

    private void Awake()
    {
        myCol = GetComponent<Collider2D>();
        if (myCol == null)myCol = gameObject.AddComponent<CircleCollider2D>();
        myCol.isTrigger = true;// Triggerにして物理で押さない

        var rb = GetComponent<Rigidbody2D>();
        if (rb == null)rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;// 物理反応しない
        rb.gravityScale = 0f;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 進む（2DなのでZは無視）
        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);

        // 一定時間で自動爆発
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Explode();
        }
    }

    // 何かに触れたら爆発（弾のCollider2Dは isTrigger をONにしておく）
    void OnTriggerEnter2D(Collider2D other)
    {
        // 敵に当たったら爆発&敵を消す
        if (other.CompareTag(targetTag))
        {
            
            Explode();// 爆発エフェクト
            
        }
        
    }

    void Explode()
    {
        AudioManager.Instance.PlaySEById(SEName.BombArrow);
        // 見た目の爆発を出す（なくてもOK）
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // 弾そのものは消える
        Destroy(gameObject);
    }
}
