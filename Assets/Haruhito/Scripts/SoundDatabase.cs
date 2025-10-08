using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "Scriptable Objects/SoundDatabase")]
public class SoundDatabase : ScriptableObject
{
    [Header("BGMクリップリスト")]
    public List<AudioClip> bgmClips = new List<AudioClip>();

    [Header("SEクリップリスト")]
    public List<AudioClip> seClips = new List<AudioClip>();

    [Header("BGM音量（0～1）")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float bgmVolume = 0.3f;

    [Header("SE音量（0～1）")]
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
