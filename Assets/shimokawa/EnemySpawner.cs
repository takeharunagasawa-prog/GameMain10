using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private Transform core;         //プレイヤーの位置情報

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
#if false
        // yu-kirohi
        // このローカル変数作る意味なくない?
        Vector3 min = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // yu-ki-rohi
        // この方法では要件を満たせてないよね

        //ランダムな位置を作る
        float x = Random.Range(minspawnRange.x, maxspawnRange.x);
        float y = Random.Range(minspawnRange.y, maxspawnRange.y);

#else
        float x, y;
        int dirJudge = Random.Range(0, 4);
        switch (dirJudge)
        {
            case 0:
                // 上から
                x = Random.Range(minspawnRange.x, maxspawnRange.x);
                y = maxspawnRange.y;
                break;
            case 1:
                // 右から
                x = maxspawnRange.x;
                y = Random.Range(minspawnRange.y, maxspawnRange.y);
                break;
            case 2:
                // 下から
                x = Random.Range(minspawnRange.x, maxspawnRange.x);
                y = minspawnRange.y;
                break;
            case 3:
                // 左から
                x = minspawnRange.x;
                y = Random.Range(minspawnRange.y, maxspawnRange.y);
                break;
            default:
                x = minspawnRange.x;
                y = minspawnRange.y;
                break;
        }
#endif

        Vector2 spawnPos = new Vector2(x, y);
        //敵を生成する
        GameObject gameObject = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        EnemiMove enemiMove = gameObject.GetComponent<EnemiMove>();
        enemiMove.SetTarget(core);
        
    }
}
