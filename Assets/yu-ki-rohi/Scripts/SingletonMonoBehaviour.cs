using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    /// <summary>
    /// �V���O���g���C���X�^���X���擾
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //  �C���X�^���X�����݂��Ȃ��ꍇ�A�V�[����������
                _instance = FindAnyObjectByType<T>();

                if (_instance == null)
                {
                    // �C���X�^���X��������Ȃ���ΐV�����쐬
                    SetupInstance();
                }
                else
                {
                    // ���ɃC���X�^���X�����݂���ꍇ�̃f�o�b�O���b�Z�[�W
                    Debug.Log($"[Singleton] Instance of {typeof(T).Name} already created: {_instance.gameObject.name}");
                }
            }

            return _instance;
        }
    }

    /// <summary>
    /// �C���X�^���X���V�[�����ɑ��݂��Ȃ��ꍇ�A�C���X�^���X���Z�b�g�A�b�v
    /// </summary>
    private static void SetupInstance()
    {
        GameObject gameObj = new GameObject(typeof(T).Name);
        _instance = gameObj.AddComponent<T>();
        DontDestroyOnLoad(gameObj);
    }

    /// <summary>
    /// �d���C���X�^���X�̏���
    /// </summary>
    protected virtual void Awake()
    {
        // �C���X�^���X�����łɑ��݂��邩�m�F���A���݂���ꍇ�͎��g��j��
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
