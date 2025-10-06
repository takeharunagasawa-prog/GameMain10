using System;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// �̗͂��Ǘ��B0�ɂȂ�������ꂽ����B
/// Player�ɂ�Enemy�ɂ��g����B
/// </summary>
public class Health : MonoBehaviour
{
    [Header("�ő�HP")]
    public int maxHP = 5;

    [Header("����HP�i�J�n���͍ő��OK�j")]
    public int currentHP;

    [Header("HP��0�ɂȂ������̃C�x���g�i�G�t�F�N�g��������j")]
    public UnityEvent onDead;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Max(currentHP, 0);

        if (currentHP <= 0)
        {
            // �܂��C�x���g�i���E�A�j�����j
            onDead?.Invoke();

            // �������Ȃ���Ώ�������
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }
}

