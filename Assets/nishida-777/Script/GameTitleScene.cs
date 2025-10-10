using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTitleScene : MonoBehaviour
{
    [SerializeField, Header("�X�^�[�g�{�^��")]
    private Button start;

   


    private void Start()
    {
     

        GameInitializer.Instance.SetUpGameInitialize();
        //�^�C�g����ʂ�BGM�Đ�

        AudioManager.Instance.PlayBGMIfNotPlaying(BGMName.Title);


    }



    /// <summary>
    /// 
    /// </summary>
    public void SceneChange()
    {
        AudioManager.Instance.PlaySEById(SEName.Click);
        SceneManager.LoadScene("GameMain");

    }
}