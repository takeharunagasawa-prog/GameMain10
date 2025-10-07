using System;
using UnityEngine;

/// <summary>
/// �܂�������Ԓe�BlifeTime �b�Ŏ��������B
/// �Ԃ�����������������B
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class BombBullet : MonoBehaviour
{
    [Header("�e�̑���")]
    [SerializeField]
    public float speed = 10f;

    [Header("���b�Ŏ����������邩")]
    [SerializeField]
    public float lifeTime = 1.5f;

    [Header("�����̌����ځiSimpleExplosion ��t�������j")]
    public GameObject explosionPrefab;

    // PlayerShooter ����n�����u�i�ތ����v
    [HideInInspector] public Vector2 moveDir = Vector2.right;

    float timer = 0f;

    void Update()
    {
        // �i�ށi2D�Ȃ̂�Z�͖����j
        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);

        // ��莞�ԂŎ�������
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Explode();
        }
    }

    // �����ɐG�ꂽ�甚���i�e��Collider2D�� isTrigger ��ON�ɂ��Ă����j
    void OnTriggerEnter2D(Collider2D other)
    {
        // �����ł͑����I�΂������i�K�v�Ȃ�^�O�ŕ���j
        Explode();
    }

    void Explode()
    {
        // �����ڂ̔������o���i�Ȃ��Ă�OK�j
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // �e���̂��̂͏�����
        Destroy(gameObject);
    }
}
