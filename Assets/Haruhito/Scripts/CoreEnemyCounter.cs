using UnityEngine;
using TMPro;

public class CoreEnemyCounter : MonoBehaviour
{
    [Header("�������Ă���G�̐���\������e�L�X�g")]
    [SerializeField] private TMP_Text coreEnemyCounterText;

    [Header("�\�����[�h�؂�ւ�")]
    [Tooltip("true = �������Ă���G�̐� / false = �c�苖�e��")]
    [SerializeField] private bool showCurrentCount = true;

    [Header("core�iCoreController�������I�u�W�F�N�g�j")]
    [SerializeField] private CoreController coreController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �\��
        UpdateEnemyCount();
    }

    // Update is called once per frame
    void Update()
    {
        // �\��
        UpdateEnemyCount();
    }

    // �������Ă���G�̐���UI���X�V���ĕ\��
    private void UpdateEnemyCount()
    {
        // �e�L�X�g�ݒ�`�F�b�N
        if (coreEnemyCounterText == null)
        {
            Debug.LogWarning("�e�L�X�g���ݒ�");
            return;
        }

        if (showCurrentCount == true)
        {
            // �u�������Ă���G�̐��v��\��
            coreEnemyCounterText.text = coreController.CurrentEnemyCount.ToString();
        }
        else
        {
            // �u�c��ς�����G�̐��v��\��
            int remaining = Mathf.Max(0, coreController.MaxEnemyCount - coreController.CurrentEnemyCount);
            coreEnemyCounterText.text = "�c��" + remaining.ToString() + "��";
        }
    }
}
