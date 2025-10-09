using System;
using UnityEngine;

/// <summary>
/// 出現したら少し大きくなって、すぐ消えるだけの簡単エフェクト
/// ・SpriteRenderer付きの丸い画像などに使う
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Explosion : MonoBehaviour
{
    [Header("どれくらいの時間で消えるか")]
    public float duration = 0.25f;

    [Header("最大の大きさ（開始時のスケール × この値）")]
    public float maxScaleMultiplier = 2.5f;

    private float time;
    private Vector3 startScale;
    private SpriteRenderer sr;

    void Awake()
    {
        startScale = transform.localScale;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        time += Time.deltaTime;
        float t = Mathf.Clamp01(time / duration);

        // スケールが大きくなる
        float scale = Mathf.Lerp(1f, maxScaleMultiplier, t);
        transform.localScale = startScale * scale;

        // だんだん透明に
        Color c = sr.color;
        c.a = 1f - t;
        sr.color = c;

        if (time >= duration)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 敵に当たったら爆発&敵を消す
        if (other.CompareTag("Enemy"))
        {

            EnemiMove enemiMove = other.GetComponent<EnemiMove>();
            if (enemiMove != null)
            {
                enemiMove.Defeated(true);
            }

        }

    }
}

