using UnityEngine;

/// <summary>
/// ���N���b�N�Ŕ��ˁB1�L�[ = ���e�e�A2�L�[ = �� �ɐؑցB
/// �E�N���b�N�܂��̓}�E�X�z�C�[���ł��g�O���ؑ։\�B
/// </summary>
public class PlayerShooterDual : MonoBehaviour
{
    public enum ProjectileType { Bomb, Arrow }

    [Header("���˂���v���n�u")]
    public GameObject bombBulletPrefab; // BombBullet ���t�����e
    public GameObject arrowPrefab;      // Arrow ���t������

    [Header("�e���o��ʒu�i�v���C���[�̎q�I�u�W�F�N�g�j")]
    public Transform shootPoint;

    [Header("���ʂ̘A�ˊԊu(�b)")]
    public float fireInterval = 0.25f;

    [Header("�����̒e��")]
    public ProjectileType currentType = ProjectileType.Bomb;

    [Header("�A�C�e�������܂Ō��ĂȂ��ꍇ�p")]
    public bool canShoot = true; // �A�C�e�����ɂ������Ȃ� false �ŊJ�n

    private float lastFireTime;

    void Update()
    {
        // ===== �e��̐ؑ� =====
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SetType(ProjectileType.Bomb); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SetType(ProjectileType.Arrow); }

        // �E�N���b�N�Ńg�O��
        if (Input.GetMouseButtonDown(1))
        {
            ToggleType();
        }

        // �}�E�X�z�C�[���Ńg�O���i��ł����ł�OK�j
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(wheel) > 0.01f)
        {
            ToggleType();
        }

        // ===== ���� =====
        if (!canShoot) return;
        if (!Input.GetMouseButton(0)) return;
        if (Time.time - lastFireTime < fireInterval) return;

        Fire();
        lastFireTime = Time.time;
    }

    void SetType(ProjectileType t)
    {
        currentType = t;
        Debug.Log("�e��؂�ւ�: " + currentType); // �m�F�p
    }

    void ToggleType()
    {
        currentType = (currentType == ProjectileType.Bomb) ? ProjectileType.Arrow : ProjectileType.Bomb;
        Debug.Log("�e��؂�ւ�: " + currentType);
    }

    void Fire()
    {
        // �}�E�X�̃��[���h���W�i2D�Ȃ̂�z=0�j
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        // ���˕���
        Vector2 dir = (mouseWorld - shootPoint.position).normalized;

        // �����ڂ̌����iZ��]�j
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotZ = Quaternion.AngleAxis(angle, Vector3.forward);

        // �e�̐����i�e��ŏo�������j
        GameObject prefab =
            (currentType == ProjectileType.Bomb) ? bombBulletPrefab : arrowPrefab;

        if (prefab == null)
        {
            Debug.LogWarning("�v���n�u���ݒ肳��Ă��܂���: " + currentType);
            return;
        }

        GameObject shot = Instantiate(prefab, shootPoint.position, rotZ);

        // ---- �e���ցu�i�ތ����v��n�� ----
        // BombBullet ��
        var bomb = shot.GetComponent<BombBullet>();
        if (bomb != null)
        {
            bomb.moveDir = dir;
            return;
        }
        // Arrow ��
        var arrow = shot.GetComponent<Arrow>();
        if (arrow != null)
        {
            arrow.moveDir = dir;
            arrow.isPlayerArrow = true;    // �딚�h�~�i�����ɓ��ĂȂ��Ȃǁj
            arrow.targetTag = "Enemy";     // �K�v�ɉ����ĕύX
            return;
        }

        // �ǂ�����t���ĂȂ��ꍇ�̕ی��iRigidBody�����̒P���ړ��j
        shot.transform.position += (Vector3)(dir * 0.1f);
    }
}

