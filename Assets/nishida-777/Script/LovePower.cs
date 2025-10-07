using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LovePower : MonoBehaviour
{
    [Header("出したいPrefab（拾えるハートなど）")]
    public GameObject prefab;

    [Header("メインカメラ（空なら自動で探す）")]
    public Camera mainCamera;

    [Header("出現間隔（秒）")]
    public float spawnInterval = 1f;

    [Header("UIゲージ（Imageコンポーネントをドラッグ）")]
    public Image gaugeImage; // fillAmountで進むゲージ

    private int collectCount = 0; // 取得した数（最大4つで満タン）

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // 出現ループを開始
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomObject()
    {
        // カメラの高さと幅を取得
        float height = mainCamera.orthographicSize * 2f;
        float width = height * mainCamera.aspect;

        // カメラ中心
        Vector3 camPos = mainCamera.transform.position;

        // 出現範囲
        float minX = camPos.x - width / 2f;
        float maxX = camPos.x + width / 2f;
        float minY = camPos.y - height / 2f;
        float maxY = camPos.y + height / 2f;

        // ランダム座標
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // オブジェクト生成
        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        // 「触れたら消える」スクリプトを追加
        obj.AddComponent<PickupLove>().Setup(this);
    }

    // ハートを拾った時に呼ばれる
    public void OnPickupCollected()
    {
        collectCount++;
        Debug.Log($"ハートを拾った！ 合計: {collectCount}");

        // fillAmount更新（4回で満タン）
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = Mathf.Clamp01(collectCount / 4f);
        }

        // もし満タンになったら何か起こす
        if (collectCount >= 4)
        {
            Debug.Log("ゲージMAX!! パワー解放！");
            // ここに必殺技などの処理を追加
        }
    }
}