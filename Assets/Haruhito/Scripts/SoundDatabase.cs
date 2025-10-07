using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "Scriptable Objects/SoundDatabase")]
public class SoundDatabase : ScriptableObject
{
    [Header("BGMクリップリスト")]
    public List<AudioClip> bgmClips = new List<AudioClip>();

    [Header("SEクリップリスト")]
    public List<AudioClip> seClips = new List<AudioClip>();
}
