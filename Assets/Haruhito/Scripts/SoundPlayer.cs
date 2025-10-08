using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // BGM
        SoundManager.Instance.PlayBGM(BGMType.Battle);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
