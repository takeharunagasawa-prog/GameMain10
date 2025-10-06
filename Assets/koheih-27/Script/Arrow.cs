using System;
using UnityEngine;

/// <summary>
/// まっすぐ飛ぶ矢。何かに当たったら壊れる。
/// Healthを持つ相手に当たるとダメージを与える。
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    [Header("飛ぶ速さ")]
    public float speed = 12f;

    [Header("何秒で自動消滅するか")]
    public float lifeTime = 3f;

    [Header("与えるダメージ量")]
    public int damage = 1;

    [Header("この矢が狙う相手のタグ（例：Enemy）")]
    public string targetTag = "Enemy";

    [HideInInspector] public Vector2 moveDir = Vector2.right;
    [HideInInspector] public bool isPlayerArrow = false;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.isKinematic = true; // 直進だけならキネマティックでOK
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // まっすぐ進む
        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    }

    // 2Dコライダーの isTrigger をONにしておくこと
    void OnTriggerEnter2D(Collider2D other)
    {
        // 同じ陣営に当たっても無視（例：プレイヤーの体に当たらないように）
        if (isPlayerArrow && other.CompareTag("Player")) return;

        // 目標タグに当たったらダメージ
        if (other.CompareTag(targetTag))
        {
            Health hp = other.GetComponent<Health>();
            if (hp) hp.TakeDamage(damage);
        }

        // 地形（"Wall"など）でも壊れてOK
        Destroy(gameObject);
    }
}
