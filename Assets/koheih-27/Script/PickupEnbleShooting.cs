using UnityEngine;

/// <summary>
/// �v���C���[���G�ꂽ��u���Ă�悤�ɂȂ�v�A�C�e��
/// �E�A�C�e������Collider2D�� isTrigger = ON �ɂ���
/// �ERigidbody2D ��t����Ȃ� Kinematic / Gravity 0 / ��]�Œ�
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class PickupEnableShooting : MonoBehaviour
{
    [Header("�E����Ώۂ̃^�O�iPlayer �Ȃǁj")]
    public string targetTag = "Player";

    private bool consumed = false; // ���d�擾�̖h�~

    void Awake()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (consumed) return;
        if (!other.CompareTag(targetTag)) return;

        // �v���C���[���̎ˌ��R���|�[�l���g���擾�i�q�R���C�_�[�΍�Őe������j
        var shooterDual = other.GetComponentInParent<PlayerShooterDual>();
        var shooterSimple = other.GetComponentInParent<PlayerShooterDual>();

        if (shooterDual != null) shooterDual.canShoot = true;
        if (shooterSimple != null) shooterSimple.canShoot = true;

        consumed = true;
        Destroy(gameObject); // 1��ŏ�����
    }
}