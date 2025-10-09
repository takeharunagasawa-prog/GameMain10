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

        GameInitializer.Instance.SetUpGameInitialize(); 

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