using System;
using UnityEngine;

/// <summary>
/// �܂�������Ԗ�B�����ɓ������������B
/// Health��������ɓ�����ƃ_���[�W��^����B
/// </summary>
public class Arrow : MonoBehaviour
{
    [Header("��ԑ���")]
    [SerializeField]
    public float speed = 12f;

    [Header("���b�Ŏ������ł��邩")]
    [SerializeField]
    public float lifeTime = 3f;

    [Header("�^����_���[�W��")]
    [SerializeField]
    public int damage = 1;

    [Header("���̖�_������̃^�O�i��FEnemy�j")]
    public string targetTag = "Enemy";

    [HideInInspector] public Vector2 moveDir = Vector2.right;
    


    

    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // �i�ށi2D�Ȃ̂�Z�͖����j
        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);
    }

    // 2D�R���C�_�[�� isTrigger ��ON�ɂ��Ă�������
    void OnTriggerEnter2D(Collider2D other)
    {
        
        // �����w�c�ɓ������Ă������i��F�v���C���[�̑̂ɓ�����Ȃ��悤�Ɂj
        if (other.CompareTag("Player")) return;

        // �ڕW�^�O�ɓ���������_���[�W
        if (other.CompareTag(targetTag))
        {
            // �G������
            EnemiMove enemiMove = other.GetComponent<EnemiMove>();
            if (enemiMove != null)
            {
                AudioManager.Instance.PlaySEById(SEName.Damage);
                enemiMove.Defeated(false);
            }

            // �������
            Destroy(gameObject);
        }
    }
}
