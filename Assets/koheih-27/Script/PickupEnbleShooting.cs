using UnityEngine;

/// <summary>
/// �v���C���[���G�ꂽ��u���Ă�悤�ɂȂ�v�A�C�e��
/// �E�A�C�e������Collider2D�� isTrigger = ON �ɂ���
/// �EPlayer�ɂ� PlayerShooterSimple ���t���Ă���O��
/// </summary>
public class PickupEnableShooting : MonoBehaviour
{
    [Header("�E����Ώۂ̃^�O�iPlayer�Ȃǁj")]
    public string targetTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;

        // �v���C���[�ɕt���Ă��� Shooter ��T��
        PlayerShooter shooter = other.GetComponent<PlayerShooter>();
        if (shooter != null)
        {
            shooter.canShoot = true; // ���Ă�悤�ɂ���I
        }

        // 1��ŏ�����
        Destroy(gameObject);
    }
}
