using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LovePower : MonoBehaviour
{
    [Header("出したいPrefab")]
    public GameObject prefab;

    [Header("メインカメラ（空なら自動）")]
    public Camera mainCamera;

    [Header("出現間隔(秒)")]
    [SerializeField] float spawnInterval = 1f;

    [Header("UIゲージ(Image)")]
    public Image gaugeImage;

    // ▼ 内部状態
    private int collectCount = 0;  // 0〜4（4で100%）
    private bool canCollect = true;
    private bool switched = false; // 100%で爆弾矢へ切替済みか

    [SerializeField] private PlayerShooterArrowSwitcher shooter;
    [SerializeField] private Image heartMax;
    [SerializeField, Range(1, 50)] private int needHeartNum = 4;
    [SerializeField] private Vector2 minSpawnRange;  //生成位置のランダム範囲
    [SerializeField] private Vector2 maxSpawnRange;

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        StartCoroutine(SpawnLoop());
        var players = GameObject.FindGameObjectWithTag("Player");
        if (players != null)
            shooter = players.GetComponent<PlayerShooterArrowSwitcher>();
        
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (canCollect) SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomObject()
    {
#if false
        // yu-ki-rohi
        // 作る前にプランナーに要件を確認しましたか?
        float height = mainCamera.orthographicSize * 2f;
        float width = height * mainCamera.aspect;
        Vector3 cam = mainCamera.transform.position;

        float x = Random.Range(cam.x - width / 2f, cam.x + width / 2f);
        float y = Random.Range(cam.y - height / 2f, cam.y + height / 2f);
#else
        
        float x, y;
        int dirJudge = Random.Range(0, 4);
        switch (dirJudge)
        {
            case 0:
                // 上側
                x = Random.Range(-maxSpawnRange.x, maxSpawnRange.x);
                y = Random.Range(minSpawnRange.y, maxSpawnRange.y);
                break;
            case 1:
                // 右側
                x = Random.Range(minSpawnRange.x, maxSpawnRange.x);
                y = Random.Range(-maxSpawnRange.y, maxSpawnRange.y);
                break;
            case 2:
                // 下側
                x = Random.Range(-maxSpawnRange.x, maxSpawnRange.x);
                y = Random.Range(-minSpawnRange.y, -maxSpawnRange.y);
                break;
            case 3:
                // 左側
                x = Random.Range(-minSpawnRange.x, -maxSpawnRange.x);
                y = Random.Range(-maxSpawnRange.y, maxSpawnRange.y);
                break;
            default:
                x = minSpawnRange.x;
                y = minSpawnRange.y;
                break;
        }
#endif
        var obj = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        obj.AddComponent<PickupLove>().Steup(this);
    }

    // ←←← ここまでが1つのメソッド群。これより下に「public void OnPickupCollected()」を
    //       新しいメソッドとして置く（他メソッドの"中"に入れない）

    public void OnPickupCollected()
    {
        if (!canCollect) return;// 満タンなら無視
        
        collectCount++;

#if false
        // yu-ki-rohi
        // 式が間違っている
        // 後マジックナンバーは避けようね
        if (gaugeImage != null)
            gaugeImage.fillAmount = Mathf.Clamp01(collectCount / collectCount); // 4回で満タン(1.0)

#else
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = Mathf.Clamp01(collectCount / (float)needHeartNum);
        }
#endif

        if (!switched && gaugeImage != null && gaugeImage.fillAmount >= 1f)
        {
            // 100% 到達で爆弾矢に切替＆以降は拾えない
             shooter?.SwitchToBomb();
            if(heartMax)
            {
                heartMax.enabled = true;
            }
            else
            {
                Debug.LogError("heartMax is Null !");
            }
            canCollect = false;// 以降は拾えない
            switched = true;
            AudioManager.Instance.PlaySEById(SEName.Charge);

            Debug.Log("LovePower MAX！爆弾矢モードへ");
        }
    }

    // ★ここがエラー箇所になりやすい：必ずクラス直下に置く
    public void ResetPower()
    {
        collectCount = 0;
        canCollect = true;
        switched = false;               // 満タンフラグも戻す

        if (gaugeImage != null) gaugeImage.fillAmount = 0f;

        // 0% になったら通常矢へ戻す
        if (shooter != null) shooter.SwitchToNormal();

        if (heartMax)
        {
            heartMax.enabled = false;
        }
        else 
        {
            Debug.LogError("heartMax is Null !");
        }
        Debug.Log("LovePowerリセット → 0% / 再取得OK / 通常矢に戻す");
    }

    // pickupから参照できる読み取り専用プロパティ
    public bool CanCollect => canCollect;
}
