using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform player;         //プレイヤーの位置情報

    [SerializeField] private GameObject enemyPrefab;  //生成する敵のプレハブ
    [SerializeField] private float spawnInterval = 5f; //生成間隔（秒）
    [SerializeField] private Vector2 minspawnRange;  //生成位置のランダム範囲
    [SerializeField] private Vector2 maxspawnRange;
    private float timer = 0f; // 時間を計るための変数
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        //プレイヤーを名前で探す
        player = GameObject.Find("Player").transform;
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //時間を進める
        timer += Time.deltaTime;

        //一定時間が経ったら敵を生成
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; //タイマーをリセット
        }
    }

    void SpawnEnemy()
    {
        Vector3 min = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
        //ランダムな位置を作る
        float x = Random.Range(minspawnRange.x, maxspawnRange.x);
        float y = Random.Range(minspawnRange.y, maxspawnRange.y);
        Vector2 spawnPos = new Vector2(x, y);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
       //敵を生成する

    }
}
