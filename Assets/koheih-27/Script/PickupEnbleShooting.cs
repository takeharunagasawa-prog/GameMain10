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
        // Rigidbody2D ������ꍇ�A���S�ݒ�ɕύX
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        // Collider2D���g���K�[���i�Ԃ���Ȃ��悤�Ɂj
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (consumed) return;
        if (!other.CompareTag(targetTag)) return;

        // �v���C���[���̎ˌ��R���|�[�l���g���擾�i�ǂ���ł��Ή��j
        var shooterDual = other.GetComponentInParent<PlayerShooterDual>();
        var shooterSimple = other.GetComponentInParent<PlayerShooterSimple>();

        if (shooterDual != null) shooterDual.canShoot = true;
        if (shooterSimple != null) shooterSimple.canShoot = true;

        // �E�����瑦����
        consumed = true;
        Destroy(gameObject);
    }
}

internal class PlayerShooterSimple
{
    internal bool canShoot;
}