using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [Header("SE�f�[�^�x�[�X")]
    [SerializeField] private SoundDatabase database;

    [Header("�����ɍĐ��ł���SE�̍ő吔")]
    [SerializeField] private int seSourceCount = 5;

    // SE���Đ����邽�߂̃X�s�[�J�[
    private List<AudioSource> seSources = new List<AudioSource>();

    // ������
    public void Init(SoundDatabase db)
    {
        database = db;

        // �w�肵������seSource��ݒ�
        for (int i = 0; i < seSourceCount; i++)
        {
            // ���ʐݒ肵�Ēǉ�
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.volume = database.SeVolume;
            seSources.Add(source);
        }
    }

    // �Đ�
    public void Play(SEType type)
    {
        // �f�[�^�x�[�X�`�F�b�N
        if (database == null)
        {
            Debug.LogWarning("SoundDatabase ���ݒ肳��Ă��܂���");
            return;
        }

        // SE�o�^�`�F�b�N
        int index = (int)type;
        if (index < 0 || index >= database.seClips.Count)
        {
            Debug.LogWarning("�Ή�����SE���ݒ肳��Ă��܂���");
        }

        AudioClip clip = database.seClips[index];

        // �Đ����Ă��Ȃ��X�s�[�J�[��T��
        foreach (AudioSource source in seSources)
        {
            // �Đ����Ă��Ȃ��ꍇ�A�ݒ肵�čĐ�
            if (source.isPlaying == false)
            {
                source.clip = clip;
                source.Play();
            }
        }

        // ������Ȃ�������A0�Ԓn�������I�Ɏg�p
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
