using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance; 

    public static SoundManager Instance
    {
        get
        {
            // このスクリプトにアクセスした時に、SoundManagerがnullだった場合
            if (instance == null)
            {
                // 新しくSoundManagerのGameObjectを作成し、シーンの削除に巻き込まれないようにする
                GameObject singletonObject = new GameObject("SoundManager");
                instance = singletonObject.AddComponent<SoundManager>();
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    // シングルトンパターンを適用
    private void Awake()
    {
        // 既にインスタンスが存在していたら、破棄
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        // シーンの削除に巻き込まれないようにする
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Header("BGMを再生するためのスピーカー")]
    private AudioSource bgmSource;

    [Header("SEを再生するためのスピーカーのリスト")]
    [Tooltip("同時に再生できるSEの最大数")]
    [SerializeField] private int seSourceCount = 5;

    [SerializeField] private List<AudioSource> seSources = new List<AudioSource>();

    [Header("オーディオクリップリスト")]
    [Tooltip("BGMやSEを管理するリスト")]
    [SerializeField] private List<AudioClip> bgmClips;
    [SerializeField] private List<AudioClip> seClips;

    public List<AudioClip> BgmClips
    {
        get { return bgmClips; }
    }

    void Start()
    {
        // BGMのスピーカーを1つ作成
        bgmSource = gameObject.AddComponent<AudioSource>();
        // BGMをループ可にする
        bgmSource.loop = true;

        // SEのスピーカーを指定した数だけ作成
        for (int i = 0; i < seSourceCount; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            seSources.Add(source);
        }
    }

    // BGMを再生する
    public void PlayBGM(AudioClip clip)
    {
        // 同じBGMが流れていたら、再生しない
        if (bgmSource.clip == clip && bgmSource.isPlaying)
        {
            return;
        }

        // BGMを設定して再生
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // SEを再生する
    public void PlaySE(AudioClip clip)
    {
        // 再生中でないスピーカーを探し、SEを設定して再生
        foreach (AudioSource source in seSources)
        {
            if (source.isPlaying == false)
            {
                source.clip = clip;
                source.Play();
                return;
            }
        }

        // 全て使用中なら、0番地を強制的に再利用
        seSources[0].clip = clip;
        seSources[0].Play();
    }

    // BGMを停止する
    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
