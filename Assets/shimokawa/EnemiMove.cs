using UnityEngine;

public class EnemiMove : MonoBehaviour
{
    public float speed = 3f;          // �G�̈ړ����x
    private Transform player;         // �v���C���[�̈ʒu���

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�v���C���[�𖼑O�ŒT��
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;//�v���C���[��������Ȃ��ꍇ�͉������Ȃ�

        // �v���C���[�̕��������߂�
        Vector2 direction = (player.position - transform.position).normalized;

        // �G���v���C���[�����ֈړ�������
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
