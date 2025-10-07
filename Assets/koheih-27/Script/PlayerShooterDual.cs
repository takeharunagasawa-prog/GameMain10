using UnityEngine;

/// <summary>
/// 左クリックで発射。1キー = 爆弾弾、2キー = 矢 に切替。
/// 右クリックまたはマウスホイールでもトグル切替可能。
/// </summary>
public class PlayerShooterDual : MonoBehaviour
{
    public enum ProjectileType { Bomb, Arrow }

    [Header("発射するプレハブ")]
    public GameObject bombBulletPrefab; // BombBullet が付いた弾
    public GameObject arrowPrefab;      // Arrow が付いた矢

    [Header("弾が出る位置（プレイヤーの子オブジェクト）")]
    public Transform shootPoint;

    [Header("共通の連射間隔(秒)")]
    public float fireInterval = 0.25f;

    [Header("初期の弾種")]
    public ProjectileType currentType = ProjectileType.Bomb;

    [Header("アイテムを取るまで撃てない場合用")]
    public bool canShoot = true; // アイテム制にしたいなら false で開始

    private float lastFireTime;

    void Update()
    {
        // ===== 弾種の切替 =====
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SetType(ProjectileType.Bomb); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SetType(ProjectileType.Arrow); }

        // 右クリックでトグル
        if (Input.GetMouseButtonDown(1))
        {
            ToggleType();
        }

        // マウスホイールでトグル（上でも下でもOK）
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(wheel) > 0.01f)
        {
            ToggleType();
        }

        // ===== 発射 =====
        if (!canShoot) return;
        if (!Input.GetMouseButton(0)) return;
        if (Time.time - lastFireTime < fireInterval) return;

        Fire();
        lastFireTime = Time.time;
    }

    void SetType(ProjectileType t)
    {
        currentType = t;
        Debug.Log("弾を切り替え: " + currentType); // 確認用
    }

    void ToggleType()
    {
        currentType = (currentType == ProjectileType.Bomb) ? ProjectileType.Arrow : ProjectileType.Bomb;
        Debug.Log("弾を切り替え: " + currentType);
    }

    void Fire()
    {
        // マウスのワールド座標（2Dなのでz=0）
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        // 発射方向
        Vector2 dir = (mouseWorld - shootPoint.position).normalized;

        // 見た目の向き（Z回転）
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotZ = Quaternion.AngleAxis(angle, Vector3.forward);

        // 弾の生成（弾種で出し分け）
        GameObject prefab =
            (currentType == ProjectileType.Bomb) ? bombBulletPrefab : arrowPrefab;

        if (prefab == null)
        {
            Debug.LogWarning("プレハブが設定されていません: " + currentType);
            return;
        }

        GameObject shot = Instantiate(prefab, shootPoint.position, rotZ);

        // ---- 弾側へ「進む向き」を渡す ----
        // BombBullet 版
        var bomb = shot.GetComponent<BombBullet>();
        if (bomb != null)
        {
            bomb.moveDir = dir;
            return;
        }
        // Arrow 版
        var arrow = shot.GetComponent<Arrow>();
        if (arrow != null)
        {
            arrow.moveDir = dir;
            arrow.isPlayerArrow = true;    // 誤爆防止（自分に当てないなど）
            arrow.targetTag = "Enemy";     // 必要に応じて変更
            return;
        }

        // どちらも付いてない場合の保険（RigidBody無しの単純移動）
        shot.transform.position += (Vector3)(dir * 0.1f);
    }
}

