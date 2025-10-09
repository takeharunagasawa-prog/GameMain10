// PlayerShooterArrowSwitcher.cs（要点だけ。FireはそのままでOK）
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooterArrowSwitcher : MonoBehaviour
{
    public enum ArrowType { Normal, Bomb }

    [Header("Prefabs")]
    public GameObject normalArrowPrefab;
    public GameObject bombArrowPrefab;

    [Header("Muzzle")]
    public Transform shootPoint;

    [Header("UI(任意)")]
    public Text typeText;

    private Animator animator;

    [SerializeField] private ArrowType currentType = ArrowType.Normal; // ← 発射に使う源泉
    [SerializeField] private LovePower love;
    [SerializeField] float fireInterval = 0.25f;
    float lastFireTime;
    public void SwitchToBomb() { currentType = ArrowType.Bomb; ApplyTypeVisuals(); }
    public void SwitchToNormal() { currentType = ArrowType.Normal; ApplyTypeVisuals(); }
    void Awake()
    {
        if (love == null) love = FindAnyObjectByType<LovePower>(); // 1回だけ取ってキャッシュ
        animator = GetComponent<Animator>();
    }


    void ApplyTypeVisuals()//消去可能
    {
        if (typeText != null)
            typeText.text = (currentType == ArrowType.Bomb) ? "💣 爆弾矢" : "▶ 通常矢";
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastFireTime >= fireInterval)
        {
            Fire();
            lastFireTime = Time.time;
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetTrigger("Move");
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetTrigger("Move");
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetTrigger("Move");
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetTrigger("Move");
            }
        }
    }

    void Fire()
    {
        if (shootPoint == null) return;
        Debug.Log("Fire: type=" + currentType);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        Vector2 dir = (mouseWorld - shootPoint.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotZ = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject prefab = (currentType == ArrowType.Normal) ? normalArrowPrefab : bombArrowPrefab;
        if (prefab == null) { Debug.LogWarning("Prefab未設定: " + currentType); return; }

        var shot = Instantiate(prefab, shootPoint.position, rotZ);
        if(currentType == ArrowType.Bomb)
        {
            Debug.LogWarning(prefab.name);
        }
        var arrow = shot.GetComponent<Arrow>(); if (arrow != null) arrow.moveDir = dir;
        var bomb = shot.GetComponent<BombBullet>(); if (bomb != null) bomb.moveDir = dir;

        // 爆弾矢を撃ったら LovePower をリセット＆通常矢へ戻す
        if (currentType == ArrowType.Bomb)
        {
            love?.ResetPower();   // 0%＆再取得許可
        }
    }
}