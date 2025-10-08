using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    public float speed = 2f;          //敵の移動速度
    private Transform core;         //プレイヤーの位置情報

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //核を名前で探す
        core = GameObject.Find("Core").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (core == null) return;//プレイヤーが見つからない場合は何もしない

        //プレイヤーの方向を求める
        Vector2 direction = (core.position - transform.position).normalized;

        //敵をプレイヤー方向へ移動させる
        transform.position = Vector2.MoveTowards(transform.position, core.position, speed * Time.deltaTime);
    }

         //プレイヤーと接触したときに呼ばれる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //もし接触した相手の名前が「Player」なら
        if (collision.gameObject.name == "core")
        {
            //敵を消す
            Destroy(gameObject);
        }
    }
}
