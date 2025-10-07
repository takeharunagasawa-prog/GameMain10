using UnityEngine;

/// <summary>
/// �v���C���[���G�ꂽ������� LovePower �ɕ񍐂���
/// </summary>
public class PickupLove : MonoBehaviour
{
    private LovePower manager;

    // �Ăяo�����iLovePower�j��o�^
    public void Setup(LovePower mgr)
    {
        manager = mgr;
        // Collider���Ȃ���Ύ����ŕt����
        var col = GetComponent<Collider2D>();
        if (col == null) col = gameObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.OnPickupCollected(); // LovePower �ɕ�
            Destroy(gameObject);         // ����������
        }
    }
}