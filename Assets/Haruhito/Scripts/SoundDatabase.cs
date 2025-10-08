using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "Scriptable Objects/SoundDatabase")]
public class SoundDatabase : ScriptableObject
{
    [Header("BGM�N���b�v���X�g")]
    public List<AudioClip> bgmClips = new List<AudioClip>();

    [Header("SE�N���b�v���X�g")]
    public List<AudioClip> seClips = new List<AudioClip>();

    [Header("BGM���ʁi0�`1�j")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float bgmVolume = 0.3f;

    [Header("SE���ʁi0�`1�j")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float seVolume = 0.3f;

    public float BgmVolume
    {
        get { return bgmVolume; }
        set { bgmVolume = value; }
    }

    public float SeVolume
    {
        get { return seVolume; }
        set { seVolume = value; }
    }
}
