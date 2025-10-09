using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;          //�G�̈ړ����x
    [SerializeField] private float vanishTime = 1.0f;
    [SerializeField] private float explossionVanishTime = 1.0f;
    [SerializeField] private Transform core;         //�j�̈ʒu���
    [SerializeField] private GameObject explossion;
    [SerializeField] private GameObject arrowHit;
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

        if (core == null) return;//�j��������Ȃ��ꍇ�͉������Ȃ�

        //�v���C���[�̕��������߂�
        Vector2 direction = (core.position - transform.position).normalized;

        //�G���v���C���[�����ֈړ�������
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public void SetTarget(Transform target)
    {
        core = target;
    }
    private void Explossion()
    {
        Instantiate(explossion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Defeated(bool isExplode)
    {
        if (!isActive) { return; }
        isActive = false;

        animator.SetTrigger("Defeated");
        if (isExplode) 
        {
            Invoke("Explossion", explossionVanishTime);
        }
        else
        {
            Instantiate(arrowHit, transform.position, Quaternion.identity);
            Destroy(gameObject, vanishTime);
        }
    }
}
