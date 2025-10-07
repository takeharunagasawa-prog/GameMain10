using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioClip clip = SoundManager.Instance.BgmClips[0];

        SoundManager.Instance.PlayBGM(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
