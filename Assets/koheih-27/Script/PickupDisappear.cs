using UnityEngine;

/// <summary>
/// �v���C���[���G�ꂽ�������A�C�e��
/// �iPickup���ɃA�^�b�`�j
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class PickupDisappear : MonoBehaviour
{
    [Header("�E����Ώۂ̃^�O�i��: Player�j")]
    public string targetTag = "Player";

    void Awake()
    {
        // ���S�ݒ�i�Փ˂ŉ�����Ȃ��悤�Ɂj
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        // Trigger �ɂ��Ă���
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    // Player���G�ꂽ�����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Player��Pickup�ɐG��܂����I");
            Destroy(gameObject);
        }
    }
}

