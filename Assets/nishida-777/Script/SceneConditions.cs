using UnityEngine;
using UnityEngine.SceneManagement;

// ゲームのシーンをまとめて管理するenum
public enum GameScene
{
    None = -1,
    GameMain,       // メインゲーム
    GameOver,   // ゲームオーバー画面
    GameClear       // クリア画面
}
public class SceneConditions : MonoBehaviour
{
    private GameScene scene = GameScene.GameMain;

    [SerializeField] CoreController coreController;

    [SerializeField]
    private int borderNum = 30;

    private bool isTimeOver = false;

    void Start()
    {
        AudioManager.Instance.PlayBGMIfNotPlaying(BGMName.Battle);
    }

    void Update()
    {
        switch(scene)
        {
            case GameScene.GameMain:

                if(coreController.IsGameOver == true)
                {

                    scene = GameScene.GameOver;
                }
                if(isTimeOver == true)
                {
                    int killNum = ScoreManager.Instance.GetKillNum();


                    if (killNum >= borderNum)
                    {
                        scene = GameScene.GameClear;
                    }
                    else
                    {
                        scene = GameScene.GameOver;
                    }
                }
                break;

            case GameScene.GameOver:
                SceneManager.LoadScene("GameOver");
                AudioManager.Instance.PlayBGMIfNotPlaying(BGMName.Failed);

                break; 

            case GameScene.GameClear:
                SceneManager.LoadScene("GameClear");
                AudioManager.Instance.PlayBGMIfNotPlaying(BGMName.Succeed);

                break;
        }
    }

    public void TimeIsOver()
    {
        AudioManager.Instance.PlayBGMIfNotPlaying(BGMName.Finish);  
        isTimeOver = true;
    }
}
