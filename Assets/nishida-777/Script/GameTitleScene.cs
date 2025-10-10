using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTitleScene : MonoBehaviour
{
    [SerializeField, Header("スタートボタン")]
    private Button start;

   


    private void Start()
    {
     

        GameInitializer.Instance.SetUpGameInitialize();
        //タイトル画面のBGM再生

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