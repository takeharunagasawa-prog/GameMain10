using UnityEngine;
using System.Collections;

public class LovePower : MonoBehaviour
{
    public GameObject prefab; // 出したいオブジェクト
    public Camera mainCamera; // メインカメラ（Inspectorで指定）
    public float spawnInterval = 1f; // 出現間隔（秒）

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // ランダム生成を繰り返すコルーチンを開始
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval); // 出現間隔を待つ
        }
    }

    void SpawnRandomObject()
    {
        // カメラの高さと幅を取得
        float height = mainCamera.orthographicSize * 2f;
        float width = height * mainCamera.aspect;

        // カメラの中心位置
        Vector3 camPos = mainCamera.transform.position;

        // 画面範囲を計算
        float minX = camPos.x - width / 2f;
        float maxX = camPos.x + width / 2f;
        float minY = camPos.y - height / 2f;
        float maxY = camPos.y + height / 2f;

        // ランダム座標
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // オブジェクトを生成
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}