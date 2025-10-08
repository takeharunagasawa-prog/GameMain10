//using UnityEngine;

//public class TimerController : MonoBehaviour
//{
//    public GameObject player;       // プレイヤーをInspectorで指定
//    public float waitTime = 3f;     // 最初に動けない時間（秒）

//    private float timer = 0f;
//    private bool isPlayerActivated = false;

//    void Start()
//    {
//        // 最初にプレイヤーの操作を止める
//        player.GetComponent<PlayerMove>().enabled = false;
//    }

//    void Update()
//    {
//        timer += Time.deltaTime;

//        if (!isPlayerActivated && timer >= waitTime)
//        {
//            // 一定時間経過後、プレイヤーを動けるようにする
//            player.GetComponent<PlayerMove>().enabled = true;
//            isPlayerActivated = true;
//        }
//    }
//}
