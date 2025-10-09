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
