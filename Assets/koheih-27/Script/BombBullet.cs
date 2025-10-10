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
    public float speed = 8f;

    [Header("���b�Ŏ����������邩")]
    [SerializeField]
    public float lifeTime = 1.2f;

    [Header("�����̌����ځiSimpleExplosion ��t�������j")]
    public GameObject explosionPrefab;

    [Header("���̖�_������̃^�O�i��FEnemy�j")]
    public string targetTag = "Enemy";

    // PlayerShooter ����n�����u�i�ތ����v
    [HideInInspector] public Vector2 moveDir = Vector2.right;

    float timer = 0f;

    // ���ˎ�(�v���C���[)���o����
    Transform owner;
    Collider2D myCol;

    public void SetOwner(Transform t)
    {
        owner = t;

        if(myCol == null) myCol = GetComponent<Collider2D>();
        if(myCol != null && owner != null)
        {
            foreach (var c in owner.GetComponentsInChildren<Collider2D>())
                Physics2D.IgnoreCollision(myCol, c, true);
        }
    }

    private void Awake()
    {
        myCol = GetComponent<Collider2D>();
        if (myCol == null)myCol = gameObject.AddComponent<CircleCollider2D>();
        myCol.isTrigger = true;// Trigger�ɂ��ĕ����ŉ����Ȃ�

        var rb = GetComponent<Rigidbody2D>();
        if (rb == null)rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;// �����������Ȃ�
        rb.gravityScale = 0f;

        Destroy(gameObject, lifeTime);
    }

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
        // �G�ɓ��������甚��&�G������
        if (other.CompareTag(targetTag))
        {
            
            Explode();// �����G�t�F�N�g
            
        }
        
    }

    void Explode()
    {
        AudioManager.Instance.PlaySEById(SEName.BombArrow);
        // �����ڂ̔������o���i�Ȃ��Ă�OK�j
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // �e���̂��̂͏�����
        Destroy(gameObject);
    }
}
