using UnityEngine;

/// <summary>
/// 2Dで上下左右に動くスクリプト
/// 簡単：矢印キー/WASDで移動、歩いているかをAnimatorに渡す
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("移動スピード(大きいほど速い)")]
    [SerializeField]
    public float moveSpeed = 5f;

    //一時的に
    [Header("動けるようになるまでの遅延時間(秒)")]
    [SerializeField] public float startDelay = 3f;

    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;

    //動けるかどうかを管理（一時的に）
    private bool canMove = false;
    private float timer = 0f;


    void Awake()
    {
        // Aガード：Playerタグ以外なら自動停止
        if (!CompareTag("Player"))
        {
            Debug.LogWarning($"{name}: TagがPlayerではないため PlayerMovement2D を無効化しました");
            enabled = false;
            return;
        }
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // なくてもOK

        // 2D見下ろしに最適化
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        //一定時間経つまで動けない（一時的に）
        timer += Time.deltaTime;
        if (timer >= startDelay)
            canMove = true;

        //動けない間は入力もアニメも更新しない（一時的に）
        if (!canMove)
        {
            // アニメーション停止用（一時的に）
            if (animator)
                animator.SetFloat("Speed", 0f);
            return;
        }

        // キーボード入力（-1～1）
        float x = Input.GetAxisRaw("Horizontal");  // A/D or ←/→
        float y = Input.GetAxisRaw("Vertical");    // W/S or ↑/↓
        input = new Vector2(x, y).normalized;      // 斜めで速くならないよう正規化

        // アニメ用の値を渡す（Animatorがある場合）
        if (animator)
        {
            animator.SetFloat("Speed", input.sqrMagnitude); // 0なら停止、>0で歩き
            animator.SetFloat("MoveX", input.x);
            animator.SetFloat("MoveY", input.y);
        }
    }

    void FixedUpdate()
    {
        //動けない間は物理移動も止める（一時的に）
        if (!canMove)
            return;

        Vector2 next = rb.position + input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(next);
    }
}