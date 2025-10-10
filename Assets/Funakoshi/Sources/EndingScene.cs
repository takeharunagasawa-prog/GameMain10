using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    [SerializeField] ContentManagement contentManagement;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        BGMName bgmName = BGMName.None;

        switch (sceneName)
        {
            case string name when name == "GameOver":
                bgmName = BGMName.Failed; // ���U���g���s��BGM��
                break;

            case string name when name == "GameClear":

                bgmName = BGMName.Succeed;
                break;
            default:
                Debug.LogWarning($"No BGM assigned for the scene '{sceneName}'.");
                return; // BGM���w�肳��Ă��Ȃ��ꍇ�͏I��

        }
        if (!string.IsNullOrEmpty(bgmName.ToString()))
        {
            AudioManager.Instance.PlayBGMIfNotPlaying(bgmName); // BGM���Đ�
            contentManagement.RunFirstContent();
        }
    }
    void Update()
    {
        if (!contentManagement.IsAllContentEnd())
        {
            contentManagement.ContentUpdate();
        }

        InputKeys();
    }
    void InputKeys()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!contentManagement.IsAllContentEnd())
            {
                contentManagement.SkipContent();
            }
        }
    }
}
