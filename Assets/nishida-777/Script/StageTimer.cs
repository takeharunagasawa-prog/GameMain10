using UnityEngine;
// TextMeshProを使う場合
using TMPro;

public class StageTimer : MonoBehaviour
{
    [Header("タイマー表示用Text")]
    public TMP_Text timerText; // TextMeshProの場合

    [Header("開始時間（秒単位）")]
    public float startTime = 60f; // 60秒＝1分

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
            // 残り時間を減らす
            currentTime -= Time.deltaTime;

            // 0以下になったら止める
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                // ここで何か終了処理を呼んでもOK
                sceneConditions.TimeIsOver();
            }

            // 表示を更新
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