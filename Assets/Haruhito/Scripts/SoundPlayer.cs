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
        // SE
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.Instance.PlaySE(SEType.Arrow);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.Instance.PlaySE(SEType.Charge);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SoundManager.Instance.PlaySE(SEType.Damage);
        }
    }
}
