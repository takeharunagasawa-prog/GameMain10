using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 180f; // ��]���x�i1�b��180�x�j

    void Update()
    {
        // Z���𒆐S�ɉ�]�i2D�Ȃ�Z����OK�j
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}