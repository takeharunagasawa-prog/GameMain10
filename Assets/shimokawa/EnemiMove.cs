using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    public float speed = 3f;          // 敵の移動速度
    private Transform player;         // プレイヤーの位置情報

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーを名前で探す
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;//プレイヤーが見つからない場合は何もしない

        // プレイヤーの方向を求める
        Vector2 direction = (player.position - transform.position).normalized;

        // 敵をプレイヤー方向へ移動させる
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
