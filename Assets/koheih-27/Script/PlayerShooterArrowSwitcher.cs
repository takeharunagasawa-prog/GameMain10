using UnityEngine;
using UnityEngine.UI; // ← UIを使う（Text / Image）

public class PlayerShooterArrowSwitcher : MonoBehaviour
{
    public enum ArrowType { Normal, Bomb }

    [Header("発射プレハブ")]
    public GameObject normalArrowPrefab;
    public GameObject bombArrowPrefab;

    [Header("発射位置")]
    public Transform shootPoint;

    [Header("クールタイム")]
    [SerializeField] float fireInterval = 0.25f;

    private ArrowType currentType = ArrowType.Normal;
    private float lastFireTime;
    void Update()
    {
        // Qキーで切り替え
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentType = (currentType == ArrowType.Normal) ? ArrowType.Bomb : ArrowType.Normal;
        }

        // 左クリックで発射
        if (Input.GetMouseButton(0) && Time.time - lastFireTime >= fireInterval)
        {
            Fire();
            lastFireTime = Time.time;
        }
    }

    void Fire()
    {
        if (shootPoint == null) return;

        // マウス位置から方向を計算
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        Vector2 dir = (mouseWorld - shootPoint.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotZ = Quaternion.AngleAxis(angle, Vector3.forward);

        // 矢の種類に応じてPrefabを選択
        GameObject prefab = (currentType == ArrowType.Normal) ? normalArrowPrefab : bombArrowPrefab;

        if (prefab != null)
        {
            GameObject shot = Instantiate(prefab, shootPoint.position, rotZ);

            // Arrow/BombBullet両対応
            var arrow = shot.GetComponent<Arrow>();
            if (arrow != null) arrow.moveDir = dir;

            var bomb = shot.GetComponent<BombBullet>();
            if (bomb != null) bomb.moveDir = dir;
        }
    }
}
