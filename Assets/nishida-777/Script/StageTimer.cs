using UnityEngine;
// TextMeshPro���g���ꍇ
using TMPro;

public class StageTimer : MonoBehaviour
{
    [Header("�^�C�}�[�\���pText")]
    public TMP_Text timerText; // TextMeshPro�̏ꍇ

    [Header("�J�n���ԁi�b�P�ʁj")]
    public float startTime = 60f; // 60�b��1��

    private float currentTime;
    private bool isRunning = true;

    [SerializeField]
    private SceneConditions sceneConditions;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (isRunning)
        {
            // �c�莞�Ԃ����炷
            currentTime -= Time.deltaTime;

            // 0�ȉ��ɂȂ�����~�߂�
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                // �����ŉ����I���������Ă�ł�OK
                sceneConditions.TimeIsOver();
            }

            // �\�����X�V
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}