using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;          //敵の移動速度
    [SerializeField] private Transform core;         //核の位置情報
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (core == null) return;//核が見つからない場合は何もしない

        //プレイヤーの方向を求める
        Vector2 direction = (core.position - transform.position).normalized;

        //敵をプレイヤー方向へ移動させる
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public void SetTarget(Transform target)
    {
        core = target;
    }
    
    public void Defeated(bool isExplode)
    {
        animator.SetTrigger("Defeated");
    }
}
