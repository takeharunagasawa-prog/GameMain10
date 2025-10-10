using System;
using UnityEngine;

/// <summary>
/// まっすぐ飛ぶ矢。何かに当たったら壊れる。
/// Healthを持つ相手に当たるとダメージを与える。
/// </summary>
public class Arrow : MonoBehaviour
{
    [Header("飛ぶ速さ")]
    [SerializeField]
    public float speed = 12f;

    [Header("何秒で自動消滅するか")]
    [SerializeField]
    public float lifeTime = 3f;

    [Header("与えるダメージ量")]
    [SerializeField]
    public int damage = 1;

    [Header("この矢が狙う相手のタグ（例：Enemy）")]
    public string targetTag = "Enemy";

    [HideInInspector] public Vector2 moveDir = Vector2.right;
    


    

    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 進む（2DなのでZは無視）
        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);
    }

    // 2Dコライダーの isTrigger をONにしておくこと
    void OnTriggerEnter2D(Collider2D other)
    {
        
        // 同じ陣営に当たっても無視（例：プレイヤーの体に当たらないように）
        if (other.CompareTag("Player")) return;

        // 目標タグに当たったらダメージ
        if (other.CompareTag(targetTag))
        {
            // 敵を消す
            EnemiMove enemiMove = other.GetComponent<EnemiMove>();
            if (enemiMove != null)
            {
                AudioManager.Instance.PlaySEById(SEName.Damage);
                enemiMove.Defeated(false);
            }

            // 矢も消す
            Destroy(gameObject);
        }
    }
}
