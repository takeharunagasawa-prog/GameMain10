using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [Header("BGMデータベース")]
    [SerializeField] private SoundDatabase database;

    [Header("BGM音量（0～1）")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float bgmVolume = 0.3f;

    // BGMを再生するためのスピーカー
    private AudioSource bgmSource;

    private void Awake()
    {
        // BGMをループ可にして、音量設定
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;
    }

    // 再生
    public void Play(BGMType type)
    {
        // データベースチェック
        if (database == null)
        {
            Debug.LogWarning("SoundDatabase が設定されていません");
            return;
        }

        // BGM登録チェック
        int index = (int)type;
        if (index < 0 || index >= database.bgmClips.Count)
        {
            Debug.LogWarning("対応するBGMが設定されていません");
        }

        AudioClip clip = database.bgmClips[index];

        // 同じ曲だった場合、再生しない
        if (bgmSource.clip == clip && bgmSource.isPlaying == true)
        {
            return;
        }

        // クリップを設定し、再生
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // 停止
    public void Stop()
    {
        bgmSource.Stop();
    }

    private void OnValidate()
    {
        if (bgmSource != null)
        {
            bgmSource.volume = bgmVolume;
        }
    }

    public void SetVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume;
    }
}
