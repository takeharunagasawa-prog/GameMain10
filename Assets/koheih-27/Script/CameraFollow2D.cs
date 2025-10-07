using UnityEngine;

/// <summary>
/// ターゲット（プレイヤー）をゆっくり追いかけるカメラ
/// </summary>
public class CameraFollow2D : MonoBehaviour
{
    [Header("追いかける対象（Playerをドラッグ）")]
    public Transform target;

    [Header("オフセット（カメラのずらし）")]
    public Vector3 offset = new Vector3(0, 0, -10f);

    [Header("なめらかさ（小→追従速い / 大→ゆっくり）")]
    public float smooth = 0.15f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 goalPos = target.position + offset;
        // ゆっくり追いつく（いきなりガクッと動かない）
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smooth);
        Debug.Log($"Camera:{transform.position}, Target:{target.position}");
    }
}

