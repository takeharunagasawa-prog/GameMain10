using System;
using UnityEngine;

/// <summary>
/// �o�������班���傫���Ȃ��āA���������邾���̊ȒP�G�t�F�N�g
/// �ESpriteRenderer�t���̊ۂ��摜�ȂǂɎg��
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Explosion : MonoBehaviour
{
    [Header("�ǂꂭ�炢�̎��Ԃŏ����邩")]
    public float duration = 0.25f;

    [Header("�ő�̑傫���i�J�n���̃X�P�[�� �~ ���̒l�j")]
    public float maxScaleMultiplier = 2.5f;

    private float time;
    private Vector3 startScale;
    private SpriteRenderer sr;

    void Awake()
    {
        startScale = transform.localScale;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        time += Time.deltaTime;
        float t = Mathf.Clamp01(time / duration);

        // �X�P�[�����傫���Ȃ�
        float scale = Mathf.Lerp(1f, maxScaleMultiplier, t);
        transform.localScale = startScale * scale;

        // ���񂾂񓧖���
        Color c = sr.color;
        c.a = 1f - t;
        sr.color = c;

        if (time >= duration)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ɓ��������甚��&�G������
        if (other.CompareTag("Enemy"))
        {

            EnemiMove enemiMove = other.GetComponent<EnemiMove>();
            if (enemiMove != null)
            {
                enemiMove.Defeated(true);
            }

        }

    }
}

