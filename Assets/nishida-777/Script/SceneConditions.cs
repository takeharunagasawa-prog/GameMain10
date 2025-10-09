using UnityEngine;
using UnityEngine.SceneManagement;

// �Q�[���̃V�[�����܂Ƃ߂ĊǗ�����enum
public enum GameScene
{
    None = -1,
    GameMain,       // ���C���Q�[��
    GameOver,   // �Q�[���I�[�o�[���
    GameClear       // �N���A���
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

                    if(killNum >= borderNum)
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
                break; 

            case GameScene.GameClear:
                SceneManager.LoadScene("GameClear");
                break;
        }
    }

    public void TimeIsOver()
    {
        isTimeOver = true;
    }
}
