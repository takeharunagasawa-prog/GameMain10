using UnityEngine;

/// <summary>
/// �^�[�Q�b�g�i�v���C���[�j���������ǂ�������J����
/// </summary>
public class CameraFollow2D : MonoBehaviour
{
    [Header("�ǂ�������ΏہiPlayer���h���b�O�j")]
    public Transform target;

    [Header("�I�t�Z�b�g�i�J�����̂��炵�j")]
    public Vector3 offset = new Vector3(0, 0, -10f);

    [Header("�Ȃ߂炩���i�����Ǐ]���� / �偨�������j")]
    public float smooth = 0.15f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 goalPos = target.position + offset;
        // �������ǂ����i�����Ȃ�K�N�b�Ɠ����Ȃ��j
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smooth);
        Debug.Log($"Camera:{transform.position}, Target:{target.position}");
    }
}

