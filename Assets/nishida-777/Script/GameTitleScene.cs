using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTitleScene : MonoBehaviour
{
    [SerializeField, Header("�X�^�[�g�{�^��")]
    private Button start;

   


    private void Start()
    {
     
        //�^�C�g����ʂ�BGM�Đ�
        SoundManager.Instance.PlayBGM(BGMType.Title);



    }


    
    /// <summary>
    /// 
    /// </summary>
    public void SceneChange()
    {

        SceneManager.LoadScene("GameMain");

    }
}