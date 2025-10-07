using UnityEngine;
using System.Collections;

public class LovePower : MonoBehaviour
{
    public GameObject prefab; // �o�������I�u�W�F�N�g
    public Camera mainCamera; // ���C���J�����iInspector�Ŏw��j
    public float spawnInterval = 1f; // �o���Ԋu�i�b�j

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // �����_���������J��Ԃ��R���[�`�����J�n
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval); // �o���Ԋu��҂�
        }
    }

    void SpawnRandomObject()
    {
        // �J�����̍����ƕ����擾
        float height = mainCamera.orthographicSize * 2f;
        float width = height * mainCamera.aspect;

        // �J�����̒��S�ʒu
        Vector3 camPos = mainCamera.transform.position;

        // ��ʔ͈͂��v�Z
        float minX = camPos.x - width / 2f;
        float maxX = camPos.x + width / 2f;
        float minY = camPos.y - height / 2f;
        float maxY = camPos.y + height / 2f;

        // �����_�����W
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // �I�u�W�F�N�g�𐶐�
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}