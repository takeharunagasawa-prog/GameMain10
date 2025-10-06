using System;
using UnityEngine;

/// <summary>
/// �܂�������Ԗ�B�����ɓ������������B
/// Health��������ɓ�����ƃ_���[�W��^����B
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    [Header("��ԑ���")]
    public float speed = 12f;

    [Header("���b�Ŏ������ł��邩")]
    public float lifeTime = 3f;

    [Header("�^����_���[�W��")]
    public int damage = 1;

    [Header("���̖�_������̃^�O�i��FEnemy�j")]
    public string targetTag = "Enemy";

    [HideInInspector] public Vector2 moveDir = Vector2.right;
    [HideInInspector] public bool isPlayerArrow = false;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.isKinematic = true; // ���i�����Ȃ�L�l�}�e�B�b�N��OK
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // �܂������i��
        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    }

    // 2D�R���C�_�[�� isTrigger ��ON�ɂ��Ă�������
    void OnTriggerEnter2D(Collider2D other)
    {
        // �����w�c�ɓ������Ă������i��F�v���C���[�̑̂ɓ�����Ȃ��悤�Ɂj
        if (isPlayerArrow && other.CompareTag("Player")) return;

        // �ڕW�^�O�ɓ���������_���[�W
        if (other.CompareTag(targetTag))
        {
            Health hp = other.GetComponent<Health>();
            if (hp) hp.TakeDamage(damage);
        }

        // �n�`�i"Wall"�Ȃǁj�ł�����OK
        Destroy(gameObject);
    }
}
