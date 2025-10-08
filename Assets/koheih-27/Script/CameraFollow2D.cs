using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("’Ç‚¤‘ÎÛi‹ó‚Å‚àOKFŽ©“®‚ÅPlayer‚ð’T‚·j")]
    [SerializeField] Transform target;

    public Vector3 offset = new Vector3(0, 0, -10);
    [Range(0.01f, 0.3f)] [SerializeField] float smooth = 0.15f;

    Vector3 vel;

    void Start()
    {
        if (target == null)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p) target = p.transform;
        }
        if (offset.z > -0.01f) offset.z = -10f;
        if (transform.parent != null) transform.SetParent(null);
    }

    void LateUpdate()
    {
        if (!target) return;
        var goal = target.position + offset;
        goal.z = -10f;
        transform.position = Vector3.SmoothDamp(transform.position, goal, ref vel, smooth);
    }
}
