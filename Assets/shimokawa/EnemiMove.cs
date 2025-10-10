using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;          //敵の移動速度
    [SerializeField] private float vanishTime = 1.0f;
    [SerializeField] private float explossionVanishTime = 1.0f;
    [SerializeField] private Transform core;         //核の位置情報
    [SerializeField] private GameObject explossion;
    [SerializeField] private GameObject arrowHit;
    [SerializeField] private GameObject enemyDrops;
    private Animator animator;
    private bool isActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) { return; }

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

    private void Vanish()
    {
        GameObject droppedItems = Instantiate(enemyDrops, transform.position, Quaternion.identity);
        EnemyDrops ed = droppedItems.GetComponent<EnemyDrops>();
        if (ed != null)
        {
            ed.SetTarget(core);
        }
        Destroy(gameObject);
    }

    private void Explossion()
    {
        GameObject explode = Instantiate(explossion, transform.position, Quaternion.identity);
        EnemyExplossion enemyExplossion = explode.GetComponent<EnemyExplossion>();
        if (enemyExplossion != null)
        {
            Debug.Log("Set");
            enemyExplossion.SetTarget(core);
        }

        Destroy(gameObject);
    }
    public void Defeated(bool isExplode)
    {
        if (!isActive) { return; }
        isActive = false;
        ScoreManager.Instance.CountKillNum();
        animator.SetTrigger("Defeated");
        if (isExplode) 
        {
            Invoke("Explossion", explossionVanishTime);
        }
        else
        {
            Instantiate(arrowHit, transform.position, Quaternion.identity);
            Invoke("Vanish",vanishTime);
        }
    }
}
