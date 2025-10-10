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

    private SpriteRenderer spriteRenderer;

    [SerializeField] private ArrowType currentType = ArrowType.Normal; // ← 発射に使う源泉
    [SerializeField] private LovePower love;
    [SerializeField] float fireInterval = 0.25f;
    float lastFireTime;
    private Vector3 targetPos = Vector3.zero;
    public void SwitchToBomb() { currentType = ArrowType.Bomb; ApplyTypeVisuals(); }
    public void SwitchToNormal() { currentType = ArrowType.Normal; ApplyTypeVisuals(); }
    void Awake()
    {
        if (love == null) love = FindAnyObjectByType<LovePower>(); // 1回だけ取ってキャッシュ
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void ApplyTypeVisuals()//消去可能
    {
        if (typeText != null)
            typeText.text = (currentType == ArrowType.Bomb) ? "💣 爆弾矢" : "▶ 通常矢";
    }

    private void Update()
    {
        // アニメ用の値を渡す（Animatorがある場合）
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0f;
        }
    }

    void Fire()
    {
        if (shootPoint == null) return;
        Debug.Log("Fire: type=" + currentType);

       
        Vector2 dir = (targetPos - shootPoint.position).normalized;

        float angle = (Mathf.Atan2(dir.y, dir.x) + Mathf.PI) * Mathf.Rad2Deg;
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