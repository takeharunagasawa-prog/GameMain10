using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance; 

    public static SoundManager Instance
    {
        get
        {
            // ���̃X�N���v�g�ɃA�N�Z�X�������ɁASoundManager��null�������ꍇ
            if (instance == null)
            {
                // �V����SoundManager��GameObject���쐬���A�V�[���̍폜�Ɋ������܂�Ȃ��悤�ɂ���
                GameObject singletonObject = new GameObject("SoundManager");
                instance = singletonObject.AddComponent<SoundManager>();
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    // �V���O���g���p�^�[����K�p
    private void Awake()
    {
        // ���ɃC���X�^���X�����݂��Ă�����A�j��
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        // �V�[���̍폜�Ɋ������܂�Ȃ��悤�ɂ���
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Header("BGM���Đ����邽�߂̃X�s�[�J�[")]
    private AudioSource bgmSource;

    [Header("SE���Đ����邽�߂̃X�s�[�J�[�̃��X�g")]
    [Tooltip("�����ɍĐ��ł���SE�̍ő吔")]
    [SerializeField] private int seSourceCount = 5;

    [SerializeField] private List<AudioSource> seSources = new List<AudioSource>();

    [Header("�I�[�f�B�I�N���b�v���X�g")]
    [Tooltip("BGM��SE���Ǘ����郊�X�g")]
    [SerializeField] private List<AudioClip> bgmClips;
    [SerializeField] private List<AudioClip> seClips;

    public List<AudioClip> BgmClips
    {
        get { return bgmClips; }
    }

    void Start()
    {
        // BGM�̃X�s�[�J�[��1�쐬
        bgmSource = gameObject.AddComponent<AudioSource>();
        // BGM�����[�v�ɂ���
        bgmSource.loop = true;

        // SE�̃X�s�[�J�[���w�肵���������쐬
        for (int i = 0; i < seSourceCount; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            seSources.Add(source);
        }
    }

    // BGM���Đ�����
    public void PlayBGM(AudioClip clip)
    {
        // ����BGM������Ă�����A�Đ����Ȃ�
        if (bgmSource.clip == clip && bgmSource.isPlaying)
        {
            return;
        }

        // BGM��ݒ肵�čĐ�
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // SE���Đ�����
    public void PlaySE(AudioClip clip)
    {
        // �Đ����łȂ��X�s�[�J�[��T���ASE��ݒ肵�čĐ�
        foreach (AudioSource source in seSources)
        {
            if (source.isPlaying == false)
            {
                source.clip = clip;
                source.Play();
                return;
            }
        }

        // �S�Ďg�p���Ȃ�A0�Ԓn�������I�ɍė��p
        seSources[0].clip = clip;
        seSources[0].Play();
    }

    // BGM���~����
    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
