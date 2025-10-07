using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "Scriptable Objects/SoundDatabase")]
public class SoundDatabase : ScriptableObject
{
    [Header("BGM�N���b�v���X�g")]
    public List<AudioClip> bgmClips = new List<AudioClip>();

    [Header("SE�N���b�v���X�g")]
    public List<AudioClip> seClips = new List<AudioClip>();
}
