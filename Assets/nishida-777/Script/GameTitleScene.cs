using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTitleScene : MonoBehaviour
{
    [SerializeField, Header("スタートボタン")]
    private Button start;

   


    private void Start()
    {
     
        //タイトル画面のBGM再生
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