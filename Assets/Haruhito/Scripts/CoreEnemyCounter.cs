using UnityEngine;
using TMPro;

public class CoreEnemyCounter : MonoBehaviour
{
    [Header("当たっている敵の数を表示するテキスト")]
    [SerializeField] private TMP_Text coreEnemyCounterText;

    [Header("表示モード切り替え")]
    [Tooltip("true = 当たっている敵の数 / false = 残り許容数")]
    [SerializeField] private bool showCurrentCount = true;

    [Header("core（CoreControllerがついたオブジェクト）")]
    [SerializeField] private CoreController coreController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 表示
        UpdateEnemyCount();
    }

    // Update is called once per frame
    void Update()
    {
        // 表示
        UpdateEnemyCount();
    }

    // 当たっている敵の数のUIを更新して表示
    private void UpdateEnemyCount()
    {
        // テキスト設定チェック
        if (coreEnemyCounterText == null)
        {
            Debug.LogWarning("テキスト未設定");
            return;
        }

        if (showCurrentCount == true)
        {
            // 「当たっている敵の数」を表示
            coreEnemyCounterText.text = coreController.CurrentEnemyCount.ToString();
        }
        else
        {
            // 「残り耐えられる敵の数」を表示
            int remaining = Mathf.Max(0, coreController.MaxEnemyCount - coreController.CurrentEnemyCount);
            coreEnemyCounterText.text = "残り" + remaining.ToString() + "体";
        }
    }
}
