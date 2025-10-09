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
    void Start()
    {

    }

    void Update()
    {
        switch(scene)
        {
            case GameScene.GameMain:

                if(coreController.IsGameOver == true)
                {
                    scene = GameScene.GameOver;
                    SceneManager.LoadScene("Game Over");
                }
                break;

            case GameScene.GameOver:

                break;
        }
    }
}
