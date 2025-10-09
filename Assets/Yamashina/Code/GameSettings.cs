using UnityEngine;

/// <summary>
/// �Q�[���̏����ݒ�N���X
/// </summary>
[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{

    #region �Q�[���̏������ʐݒ�̓����Ǘ��p�ϐ�

    /// <summary>
    /// �����ɍĐ��ł�����ʉ��̐�
    /// </summary>
    [Header("�Q�[���̏������ʐݒ�")]
    [SerializeField, Tooltip("�����ɍĐ��ł�����ʉ��̐�")]
    private int maxSeCount = 3;

    [Space(15)]

    /// <summary>
    /// ���� BGM ���� (0.0 - 1.0)
    /// </summary>
    [SerializeField, Tooltip("���� BGM ���� (0.0 - 1.0)")]
    [Range(0f, 1f)] 
    private float initialBgmVolume = 1f;

    [Space(15)]

    /// <summary>
    /// ���� SE ���� (0.0 - 1.0)
    /// </summary>
    [SerializeField, Tooltip("���� SE ���� (0.0 - 1.0)")]
    [Range(0f, 1f)]
    private float initialSeVolume = 1f;

    #endregion


    #region �Q�[���̂��̑������ݒ�̓����Ǘ��p�ϐ�

    [Space(15)] 

    /// <summary>
    /// �t�F�[�h�̑��x
    /// </summary>
    [Header("�Q�[���̂��̑������ݒ�")]
    [SerializeField, Tooltip("�t�F�[�h�̑��x")] 
    private float fadeSpeed = 1f;

    /// <summary>
    /// ���g���C���Ȃǂ̑ҋ@���� (ms)
    /// </summary>
    [SerializeField, Tooltip("���g���C���Ȃǂ̑ҋ@���� (ms)")]
    private int retryDelayMilliseconds = 100;

    #endregion


    #region�@�ǂݎ���p�t�B�[���h( �Q�[���̏������ʐݒ�̓����Ǘ��p�ϐ�)

    /// <summary>
    /// �����ɍĐ��ł�����ʉ��̐��̓ǂݎ���p
    /// </summary>
    internal int MaxSeCount => maxSeCount;

    /// <summary>
    /// ���� BGM ���� (0.0 - 1.0)�̓ǂݎ���p
    /// </summary>
    internal float InitialBgmVolume => initialBgmVolume;

    /// <summary>
    /// ���� SE ���� (0.0 - 1.0)�̓ǂݎ���p
    /// </summary>
    internal float InitialSeVolume => initialSeVolume;

    #endregion


    #region�@�ǂݎ���p�t�B�[���h( �Q�[���̂��̑������ݒ�̓����Ǘ��p�ϐ�)

    /// <summary>
    /// �t�F�[�h�̑��x�̓ǂݎ���p
    /// </summary>
    internal float FadeSpeed => fadeSpeed;

    /// <summary>
    /// ���g���C���Ȃǂ̑ҋ@���� (ms)�̓ǂݎ���p
    /// </summary>
    internal int RetryDelayMilliseconds => retryDelayMilliseconds;

    #endregion

}
