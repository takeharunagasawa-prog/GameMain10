using UnityEngine;
using System.Collections.Generic;

public class CoreController : MonoBehaviour
{
    [Header("�Q�[���I�[�o�[�ɂȂ�G�̐�")]
    [SerializeField] private int maxEnemyCount = 10;

    [Header("���݃R�A�ɐG��Ă���G�̐�")]
    [SerializeField] private int currentEnemyCount = 0;

    [Header("�Q�[���I�[�o�[�̃t���O")]
    [SerializeField] private bool isGameOver = false;

    // Core�ɓ������Ă���G�̃��X�g
    private readonly List<Rigidbody2D> touchingEnemies = new List<Rigidbody2D>();

    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    public int MaxEnemyCount
    {
        get { return maxEnemyCount; }
        set { maxEnemyCount = value; }
    }

    public int CurrentEnemyCount
    {
        get { return currentEnemyCount; }
        set { currentEnemyCount = value; }
    }

    // �G�����������u��
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �^�O��Enemy�Ȃ�A�������Ă���G�̐��𑝂₷
        if (other.CompareTag("Enemy"))
        {
            // Enemy��Rigidbody2D���擾
            Rigidbody2D enemyRb = other.attachedRigidbody;

            // Enemy��Rigidbody2D��null�łȂ����A���������G�����X�g�ɓ����Ă��Ȃ��ꍇ�i�d���h�~�j
            if (enemyRb != null && touchingEnemies.Contains(enemyRb) == false)
            {
                // ���X�g�ɒǉ����A���X�g�̐��ŊǗ�
                touchingEnemies.Add(enemyRb);
                AudioManager.Instance.PlaySEById(SEName.Noroi);
                currentEnemyCount = touchingEnemies.Count;
            }
        }

        // �Q�[���I�[�o�[�ɂȂ�G�̐��ȏ�ɂȂ�����A�t���O�𗧂Ă�
        if (currentEnemyCount >= maxEnemyCount)
        {
            isGameOver = true;
        }
    }

    // �G�����ꂽ�u��
    private void OnTriggerExit2D(Collider2D other)
    {
        // �^�O��Enemy�Ȃ�A�������Ă���G�̐������炷
        if (other.CompareTag("Enemy"))
        {
            // Enemy��Rigidbody2D���擾
            Rigidbody2D enemyRb = other.attachedRigidbody;

            //  Enemy��Rigidbody2D��null�łȂ����A���������G�����X�g�ɓ����Ă���ꍇ
            if (enemyRb != null && touchingEnemies.Contains(enemyRb) == true)
            {
                // ���X�g����폜���A���X�g�̐��ŊǗ�
                touchingEnemies.Remove(enemyRb);
                currentEnemyCount = touchingEnemies.Count;
            }
        }
    }
}
