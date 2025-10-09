using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
                   SoundManager.Instance.PlaySE(SEType.Click));
    }
    public void ExitingGame()
    {
      
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了


#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

}
