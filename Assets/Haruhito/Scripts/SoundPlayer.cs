using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.PlayBGM(SoundManager.bgmClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
