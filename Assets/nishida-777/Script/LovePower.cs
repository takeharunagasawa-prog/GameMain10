using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LovePower : MonoBehaviour
{
    [Header("�o������Prefab�i�E����n�[�g�Ȃǁj")]
    public GameObject prefab;

    [Header("���C���J�����i��Ȃ玩���ŒT���j")]
    public Camera mainCamera;

    [Header("�o���Ԋu�i�b�j")]
    public float spawnInterval = 1f;

    [Header("UI�Q�[�W�iImage�R���|�[�l���g���h���b�O�j")]
    public Image gaugeImage; // fillAmount�Ői�ރQ�[�W

    private int collectCount = 0; // �擾�������i�ő�4�Ŗ��^���j

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // �o�����[�v���J�n
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomObject()
    {
        // �J�����̍����ƕ����擾
        float height = mainCamera.orthographicSize * 2f;
        float width = height * mainCamera.aspect;

        // �J�������S
        Vector3 camPos = mainCamera.transform.position;

        // �o���͈�
        float minX = camPos.x - width / 2f;
        float maxX = camPos.x + width / 2f;
        float minY = camPos.y - height / 2f;
        float maxY = camPos.y + height / 2f;

        // �����_�����W
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // �I�u�W�F�N�g����
        GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

        // �u�G�ꂽ�������v�X�N���v�g��ǉ�
        obj.AddComponent<PickupLove>().Setup(this);
    }

    // �n�[�g���E�������ɌĂ΂��
    public void OnPickupCollected()
    {
        collectCount++;
        Debug.Log($"�n�[�g���E�����I ���v: {collectCount}");

        // fillAmount�X�V�i4��Ŗ��^���j
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = Mathf.Clamp01(collectCount / 4f);
        }

        // �������^���ɂȂ����牽���N����
        if (collectCount >= 4)
        {
            Debug.Log("�Q�[�WMAX!! �p���[����I");
            // �����ɕK�E�Z�Ȃǂ̏�����ǉ�
        }
    }
}