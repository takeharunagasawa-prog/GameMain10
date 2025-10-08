using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CoreController : MonoBehaviour
{
    [Header("ゲームオーバーになる敵の数")]
    [SerializeField] private int maxEnemyCount = 10;

    [Header("現在コアに触れている敵の数")]
    [SerializeField] private int currentEnemyCount = 0;

    /*
    [Header("敵の数を表示するTextMeshProのUI")]
    [SerializeField] private TMP_Text enemyCountText;

    [Header("表示モード切り替え")]
    [Tooltip("true = 当たっている敵の数 / false = 残り許容数")]
    [SerializeField] private bool showCurrentCount = true;
    */

    [Header("ゲームオーバーのフラグ")]
    [SerializeField] private bool isGameOver = false;

    // Coreに当たっている敵のリスト
    private readonly List<Rigidbody2D> touchingEnemies = new List<Rigidbody2D>();

    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    private void Start()
    {
        // UpdateEnemyCountUI();
    }

    // 敵が当たっている時
    private void OnTriggerEnter2D(Collider2D other)
    {
        // タグがEnemyなら、当たっている敵の数を増やす
        if (other.CompareTag("Enemy"))
        {
            // EnemyのRigidbody2Dを取得
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            // EnemyのRigidbody2Dがnullでないかつ、当たった敵がリストに入っていない場合（重複防止）
            if (enemyRb != null && touchingEnemies.Contains(enemyRb) == false)
            {
                // リストに追加し、リストの数で管理
                touchingEnemies.Add(enemyRb);
                currentEnemyCount = touchingEnemies.Count;
                // UpdateEnemyCountUI();
            }
        }

        // ゲームオーバーになる敵の数以上になったら、フラグを立てる
        if (currentEnemyCount >= maxEnemyCount)
        {
            isGameOver = true;
        }
    }

    // 敵が離れた時
    private void OnTriggerExit2D(Collider2D other)
    {
        // タグがEnemyなら、当たっている敵の数を減らす
        if (other.CompareTag("Enemy"))
        {
            // EnemyのRigidbody2Dを取得
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            //  EnemyのRigidbody2Dがnullでないかつ、当たった敵がリストに入っている場合
            if (enemyRb != null && touchingEnemies.Contains(enemyRb) == true)
            {
                // リストから削除し、リストの数で管理
                touchingEnemies.Remove(enemyRb);
                currentEnemyCount = touchingEnemies.Count;
                // UpdateEnemyCountUI();
            }
        }
    }

    /*
    // 当たっている敵の数をカウント・更新
    private void UpdateEnemyCountUI()
    {
        // テキスト設定チェック
        if (enemyCountText == null) return;

        if (showCurrentCount == true)
        {
            // 「当たっている敵の数」を表示
            enemyCountText.text = $"{currentEnemyCount}";
        }
        else
        {
            // 「残り耐えられる敵の数」を表示
            int remaining = Mathf.Max(0, maxEnemyCount - currentEnemyCount);
            enemyCountText.text = $"{remaining}";
        }
    }
    */
}
