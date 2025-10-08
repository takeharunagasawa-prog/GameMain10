using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [Header("BGM�f�[�^�x�[�X")]
    [SerializeField] private SoundDatabase database;

    // BGM���Đ����邽�߂̃X�s�[�J�[
    private AudioSource bgmSource;

    // ������
    public void Init(SoundDatabase db)
    {
        database = db;

        // BGM�����[�v�ɂ��āA���ʐݒ�
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.volume = database.BgmVolume;
    }

    // �Đ�
    public void Play(BGMType type)
    {
        // �f�[�^�x�[�X�`�F�b�N
        if (database == null)
        {
            Debug.LogWarning("SoundDatabase ���ݒ肳��Ă��܂���");
            return;
        }

        // BGM�o�^�`�F�b�N
        int index = (int)type;
        if (index < 0 || index >= database.bgmClips.Count)
        {
            Debug.LogWarning("�Ή�����BGM���ݒ肳��Ă��܂���");
        }

        AudioClip clip = database.bgmClips[index];

        // �����Ȃ������ꍇ�A�Đ����Ȃ�
        if (bgmSource.clip == clip && bgmSource.isPlaying == true)
        {
            return;
        }

        // �N���b�v��ݒ肵�A�Đ�
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // ��~
    public void Stop()
    {
        bgmSource.Stop();
    }

    private void OnValidate()
    {
        if (bgmSource != null)
        {
            bgmSource.volume = database.BgmVolume;
        }
    }

    public void SetVolume(float volume)
    {
        database.BgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = database.BgmVolume;
    }
}
