using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;          //�G�̈ړ����x
    [SerializeField] private Transform core;         //�j�̈ʒu���
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    
    public void Defeated(bool isExplode)
    {
        animator.SetTrigger("Defeated");
    }
}
