using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CoreController : MonoBehaviour
{
    [Header("�Q�[���I�[�o�[�ɂȂ�G�̐�")]
    [SerializeField] private int maxEnemyCount = 10;

    [Header("���݃R�A�ɐG��Ă���G�̐�")]
    [SerializeField] private int currentEnemyCount = 0;

    /*
    [Header("�G�̐���\������TextMeshPro��UI")]
    [SerializeField] private TMP_Text enemyCountText;

    [Header("�\�����[�h�؂�ւ�")]
    [Tooltip("true = �������Ă���G�̐� / false = �c�苖�e��")]
    [SerializeField] private bool showCurrentCount = true;
    */

    [Header("�Q�[���I�[�o�[�̃t���O")]
    [SerializeField] private bool isGameOver = false;

    // Core�ɓ������Ă���G�̃��X�g
    private readonly List<Rigidbody2D> touchingEnemies = new List<Rigidbody2D>();

    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    private void Start()
    {
        // UpdateEnemyCountUI();
    }

    // �G���������Ă��鎞
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �^�O��Enemy�Ȃ�A�������Ă���G�̐��𑝂₷
        if (other.CompareTag("Enemy"))
        {
            // Enemy��Rigidbody2D���擾
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            // Enemy��Rigidbody2D��null�łȂ����A���������G�����X�g�ɓ����Ă��Ȃ��ꍇ�i�d���h�~�j
            if (enemyRb != null && touchingEnemies.Contains(enemyRb) == false)
            {
                // ���X�g�ɒǉ����A���X�g�̐��ŊǗ�
                touchingEnemies.Add(enemyRb);
                currentEnemyCount = touchingEnemies.Count;
                // UpdateEnemyCountUI();
            }
        }

        // �Q�[���I�[�o�[�ɂȂ�G�̐��ȏ�ɂȂ�����A�t���O�𗧂Ă�
        if (currentEnemyCount >= maxEnemyCount)
        {
            isGameOver = true;
        }
    }

    // �G�����ꂽ��
    private void OnTriggerExit2D(Collider2D other)
    {
        // �^�O��Enemy�Ȃ�A�������Ă���G�̐������炷
        if (other.CompareTag("Enemy"))
        {
            // Enemy��Rigidbody2D���擾
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            //  Enemy��Rigidbody2D��null�łȂ����A���������G�����X�g�ɓ����Ă���ꍇ
            if (enemyRb != null && touchingEnemies.Contains(enemyRb) == true)
            {
                // ���X�g����폜���A���X�g�̐��ŊǗ�
                touchingEnemies.Remove(enemyRb);
                currentEnemyCount = touchingEnemies.Count;
                // UpdateEnemyCountUI();
            }
        }
    }

    /*
    // �������Ă���G�̐����J�E���g�E�X�V
    private void UpdateEnemyCountUI()
    {
        // �e�L�X�g�ݒ�`�F�b�N
        if (enemyCountText == null) return;

        if (showCurrentCount == true)
        {
            // �u�������Ă���G�̐��v��\��
            enemyCountText.text = $"{currentEnemyCount}";
        }
        else
        {
            // �u�c��ς�����G�̐��v��\��
            int remaining = Mathf.Max(0, maxEnemyCount - currentEnemyCount);
            enemyCountText.text = $"{remaining}";
        }
    }
    */
}
