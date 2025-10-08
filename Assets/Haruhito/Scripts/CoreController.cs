using UnityEngine;
using TMPro;

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
            Debug.Log("�J�E���g");
            currentEnemyCount++;
            // UpdateEnemyCountUI();
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
            currentEnemyCount--;
            // UpdateEnemyCountUI();
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
