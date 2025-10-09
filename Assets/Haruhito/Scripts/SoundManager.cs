using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    // �f�[�^�x�[�X
    [SerializeField] private SoundDatabase database;

    private BGMManager bgmManager;

    private SEManager seManager;

    // �V���O���g���p�^�[��
    private void Awake()
    {
        // ���ɃC���X�^���X�����݂���ꍇ�A�j��
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // �e�}�l�[�W���[�𐶐�
        bgmManager = new GameObject("BGMManager").AddComponent<BGMManager>();
        seManager = new GameObject("SEManager").AddComponent<SEManager>();

        // �f�[�^�x�[�X��n��
        bgmManager.GetType().GetField("database", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(bgmManager, database);
        seManager.GetType().GetField("database", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(seManager, database);

        // ������
        bgmManager.Init(database);
        seManager.Init(database);
    }

    // �O�����瑀��ł���悤�ɂ���
    public void PlayBGM(BGMType type) => bgmManager.Play(type);
    public void StopBGM() => bgmManager.Stop();
    public void PlaySE(SEType type) => seManager.Play(type);

    public void SetBGMVolume(float volume) => bgmManager.SetVolume(volume);
    public void SetSEVolume(float volume) => seManager.SetVolume(volume);
}
