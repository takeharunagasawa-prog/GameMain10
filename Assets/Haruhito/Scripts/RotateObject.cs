using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 180f; // 回転速度（1秒で180度）

    void Update()
    {
        // Z軸を中心に回転（2DならZ軸でOK）
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}