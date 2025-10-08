using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [Header("SEデータベース")]
    [SerializeField] private SoundDatabase database;

    [Header("同時に再生できるSEの最大数")]
    [SerializeField] private int seSourceCount = 5;

    // SEを再生するためのスピーカー
    private List<AudioSource> seSources = new List<AudioSource>();

    // 初期化
    public void Init(SoundDatabase db)
    {
        database = db;

        // 指定した数のseSourceを設定
        for (int i = 0; i < seSourceCount; i++)
        {
            // 音量設定して追加
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.volume = database.SeVolume;
            seSources.Add(source);
        }
    }

    // 再生
    public void Play(SEType type)
    {
        // データベースチェック
        if (database == null)
        {
            Debug.LogWarning("SoundDatabase が設定されていません");
            return;
        }

        // SE登録チェック
        int index = (int)type;
        if (index < 0 || index >= database.seClips.Count)
        {
            Debug.LogWarning("対応するSEが設定されていません");
        }

        AudioClip clip = database.seClips[index];

        // 再生していないスピーカーを探す
        foreach (AudioSource source in seSources)
        {
            // 再生していない場合、設定して再生
            if (source.isPlaying == false)
            {
                source.clip = clip;
                source.Play();
            }
        }

        // 見つからなかったら、0番地を強制的に使用
        seSources[0].clip = clip;
        seSources[0].Play();
    }

    private void OnValidate()
    {
        foreach (AudioSource source in seSources)
        {
            if (source != null)
            {
                source.volume = database.SeVolume;
            }
        }
    }

    public void SetVolume(float volume)
    {
        database.SeVolume = Mathf.Clamp01(volume);
        foreach (AudioSource source in seSources)
        {
            source.volume = database.SeVolume;
        }
    }
}
