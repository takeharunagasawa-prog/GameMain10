using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform player;         // プレイヤーの位置情報

    [SerializeField] private GameObject enemyPrefab;  // 生成する敵のプレハブ
    [SerializeField] private float spawnInterval = 5f; // 生成間隔（秒）
    [SerializeField] private float spawnRange = 8f;    // 生成位置のランダム範囲
    private float timer = 0f; // 時間を計るための変数

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーを名前で探す
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 時間を進める
        timer += Time.deltaTime;

        // 一定時間が経ったら敵を生成
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // タイマーをリセット
        }
    }

    void SpawnEnemy()
    {
        // ランダムな位置を作る
        Vector2 spawnPos = new Vector2(
            Random.Range(-spawnRange, spawnRange),
            Random.Range(-spawnRange, spawnRange)
        );

        // 敵を生成する
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
