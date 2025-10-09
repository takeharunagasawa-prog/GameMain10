using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreEnemyCounter : MonoBehaviour
{
    [Header("�������Ă���G�̐���\������e�L�X�g")]
    [SerializeField] private TMP_Text coreEnemyCounterText;

    [Header("�������Ă���G�̐���\������X���C�_�[")]
    [SerializeField] private Slider coreEnemyCounterSlider;

    [Header("�\�����[�h�؂�ւ�")]
    [Tooltip("true = �������Ă���G�̐� / false = �c�苖�e��")]
    [SerializeField] private bool showCurrentCount = true;

    [Header("Core�iCoreController�������I�u�W�F�N�g�j")]
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
        // UI�ݒ�`�F�b�N
        if (coreEnemyCounterText == null && coreEnemyCounterSlider == null)
        {
            Debug.LogWarning("UI���ݒ�");
            return;
        }
        else
        {
            // �e�L�X�g�ݒ�`�F�b�N
            if (coreEnemyCounterText != null)
            {
                UpdateEnemyCountText();
            }

            // �X���C�_�[�ݒ�`�F�b�N
            if (coreEnemyCounterSlider != null)
            {
                UpdateEnemyCountSlider();
            }
        }
    }

    // �e�L�X�g�X�V
    private void UpdateEnemyCountText()
    {
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

    // �X���C�_�[�X�V
    private void UpdateEnemyCountSlider()
    {
        if (showCurrentCount == true)
        {
            // 0�`1�ɕϊ�
            float value = (float)coreController.CurrentEnemyCount / coreController.MaxEnemyCount;
            // �u�������Ă���G�̐��v��\��
            coreEnemyCounterSlider.value = value;
        }
        else
        {
            // �u�c��ς�����G�̐��v��\��
            int remaining = Mathf.Max(0, coreController.MaxEnemyCount - coreController.CurrentEnemyCount);
            // 0�`1�ɕϊ�
            float value = (float)remaining / coreController.MaxEnemyCount;
            // �u�������Ă���G�̐��v��\��
            coreEnemyCounterSlider.value = value;
        }
    }
}
