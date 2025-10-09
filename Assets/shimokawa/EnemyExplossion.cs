using UnityEngine;

public class EnemyExplossion : MonoBehaviour
{
    private Transform coreTransform;
    [SerializeField] private GameObject enemyDrops;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiMove enemiMove = other.GetComponent<EnemiMove>();
            if( enemiMove == null ) {return;}
            enemiMove.Defeated(true);
        }
    }

    public void SetTarget(Transform target)
    {
        coreTransform = target;
    }

    public void Finish()
    {
        GameObject droppedItems = Instantiate(enemyDrops, transform.position, Quaternion.identity);
        EnemyDrops ed = droppedItems.GetComponent<EnemyDrops>();
        if (ed != null)
        {
            ed.SetTarget(coreTransform);
        }
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
