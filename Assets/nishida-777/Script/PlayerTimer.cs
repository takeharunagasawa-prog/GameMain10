//using UnityEngine;

//public class TimerController : MonoBehaviour
//{
//    public GameObject player;       // �v���C���[��Inspector�Ŏw��
//    public float waitTime = 3f;     // �ŏ��ɓ����Ȃ����ԁi�b�j

//    private float timer = 0f;
//    private bool isPlayerActivated = false;

//    void Start()
//    {
//        // �ŏ��Ƀv���C���[�̑�����~�߂�
//        player.GetComponent<PlayerMove>().enabled = false;
//    }

//    void Update()
//    {
//        timer += Time.deltaTime;

//        if (!isPlayerActivated && timer >= waitTime)
//        {
//            // ��莞�Ԍo�ߌ�A�v���C���[�𓮂���悤�ɂ���
//            player.GetComponent<PlayerMove>().enabled = true;
//            isPlayerActivated = true;
//        }
//    }
//}
