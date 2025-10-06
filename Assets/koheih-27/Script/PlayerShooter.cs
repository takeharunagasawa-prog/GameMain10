using System;
using UnityEngine;

/// <summary>
/// �v���C���[���e���������̒��V���v����
/// �E���N���b�N�Ŕ���
/// �E���Ԋu�ł������ĂȂ��i�A�˂������h�~�j
/// �E�ucanShoot�v��true�̎��������Ă�i�A�C�e���擾��ON�j
/// </summary>
public class PlayerShooter : MonoBehaviour
{
    [Header("�e�̃v���n�u�iBombBullet ��t�������j")]
    public GameObject bulletPrefab;

    [Header("�e���o��ʒu�i�v���C���[�̎q�I�u�W�F�N�g�j")]
    public Transform shootPoint;

    [Header("�A�ˊԊu�i�b�j")]
    public float fireInterval = 0.25f;

    [Header("�A�C�e�������܂Ō��ĂȂ�")]
    public bool canShoot = false; // �� �ŏ��� false�i�A�C�e���� true �ɂȂ�j

    private float lastFireTime;

    void Update()
    {
        if (!canShoot) return;                      // ���ĂȂ����[�h�Ȃ牽�����Ȃ�
        if (!Input.GetMouseButton(0)) return;       // ���N���b�N��������ĂȂ���Ή������Ȃ�
        if (Time.time - lastFireTime < fireInterval) return; // �Ԋu���Z�������猂���Ȃ�

        Shoot();
        lastFireTime = Time.time;
    }

    void Shoot()
    {
        // �}�E�X�̃��[���h���W�i2D�Ȃ̂�Z=0�ɂ���j
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        // ���˕����i�x�N�g���j�����
        Vector2 dir = (mouseWorld - shootPoint.position).normalized;

        // �e�����
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // �e�ɕ�����������
        BombBullet bomb = bullet.GetComponent<BombBullet>();
        bomb.moveDir = dir;
    }
}

