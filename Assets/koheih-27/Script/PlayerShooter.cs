using System;
using UnityEngine;

/// <summary>
/// プレイヤーが弾を撃つだけの超シンプル版
/// ・左クリックで発射
/// ・一定間隔でしか撃てない（連射しすぎ防止）
/// ・「canShoot」がtrueの時だけ撃てる（アイテム取得でON）
/// </summary>
public class PlayerShooter : MonoBehaviour
{
    [Header("弾のプレハブ（BombBullet を付けた物）")]
    public GameObject bulletPrefab;

    [Header("弾が出る位置（プレイヤーの子オブジェクト）")]
    public Transform shootPoint;

    [Header("連射間隔（秒）")]
    public float fireInterval = 0.25f;

    [Header("アイテムを取るまで撃てない")]
    public bool canShoot = false; // ← 最初は false（アイテムで true になる）

    private float lastFireTime;

    void Update()
    {
        if (!canShoot) return;                      // 撃てないモードなら何もしない
        if (!Input.GetMouseButton(0)) return;       // 左クリックが押されてなければ何もしない
        if (Time.time - lastFireTime < fireInterval) return; // 間隔が短すぎたら撃たない

        Shoot();
        lastFireTime = Time.time;
    }

    void Shoot()
    {
        // マウスのワールド座標（2DなのでZ=0にする）
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        // 発射方向（ベクトル）を作る
        Vector2 dir = (mouseWorld - shootPoint.position).normalized;

        // 弾を作る
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // 弾に方向を教える
        BombBullet bomb = bullet.GetComponent<BombBullet>();
        bomb.moveDir = dir;
    }
}

