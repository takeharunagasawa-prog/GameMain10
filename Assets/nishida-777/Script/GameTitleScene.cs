using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitleScene : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("GameMain");

    }
}