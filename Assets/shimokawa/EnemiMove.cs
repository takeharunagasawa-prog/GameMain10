using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    public float speed = 2f;          //�G�̈ړ����x
    private Transform core;         //�v���C���[�̈ʒu���

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�j�𖼑O�ŒT��
        core = GameObject.Find("Core").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (core == null) return;//�v���C���[��������Ȃ��ꍇ�͉������Ȃ�

        //�v���C���[�̕��������߂�
        Vector2 direction = (core.position - transform.position).normalized;

        //�G���v���C���[�����ֈړ�������
        transform.position = Vector2.MoveTowards(transform.position, core.position, speed * Time.deltaTime);
    }

         //�v���C���[�ƐڐG�����Ƃ��ɌĂ΂��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����ڐG��������̖��O���uPlayer�v�Ȃ�
        if (collision.gameObject.name == "core")
        {
            //�G������
            Destroy(gameObject);
        }
    }
}
