using System;
using UnityEngine;

/// <summary>
/// 2D�ŏ㉺���E�ɓ����X�N���v�g
/// �ȒP�F���L�[/WASD�ňړ��A�����Ă��邩��Animator�ɓn��
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("�ړ��X�s�[�h(�傫���قǑ���)")]
    [SerializeField]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>(); // �Ȃ��Ă�OK
    }

    void Update()
    {
        // �L�[�{�[�h���́i-1�`1�j
        float x = Input.GetAxisRaw("Horizontal");  // A/D or ��/��
        float y = Input.GetAxisRaw("Vertical");    // W/S or ��/��
        input = new Vector2(x, y).normalized;      // �΂߂ő����Ȃ�Ȃ��悤���K��

        // �A�j���p�̒l��n���iAnimator������ꍇ�j
        if (animator)
        {
            animator.SetFloat("Speed", input.sqrMagnitude); // 0�Ȃ��~�A>0�ŕ���
            animator.SetFloat("MoveX", input.x);
            animator.SetFloat("MoveY", input.y);
        }
    }

    void FixedUpdate()
    {
        // �����̃t���[���ňړ�������
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }
}