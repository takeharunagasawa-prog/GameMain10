using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    // データベース
    [SerializeField] private SoundDatabase database;

    private BGMManager bgmManager;

    private SEManager seManager;

    // シングルトンパターン
    private void Awake()
    {
        // 既にインスタンスが存在する場合、破棄
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 各マネージャーを生成
        bgmManager = new GameObject("BGMManager").AddComponent<BGMManager>();
        seManager = new GameObject("SEManager").AddComponent<SEManager>();

        // データベースを渡す
        bgmManager.GetType().GetField("database", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(bgmManager, database);
        seManager.GetType().GetField("database", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(seManager, database);

        // 初期化
        bgmManager.Init(database);
        seManager.Init(database);
    }

    // 外部から操作できるようにする
    public void PlayBGM(BGMType type) => bgmManager.Play(type);
    public void StopBGM() => bgmManager.Stop();
    public void PlaySE(SEType type) => seManager.Play(type);

    public void SetBGMVolume(float volume) => bgmManager.SetVolume(volume);
    public void SetSEVolume(float volume) => seManager.SetVolume(volume);
}
