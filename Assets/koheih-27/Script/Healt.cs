using System;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// 体力を管理。0になったらやられた判定。
/// PlayerにもEnemyにも使える。
/// </summary>
public class Health : MonoBehaviour
{
    [Header("最大HP")]
    public int maxHP = 5;

    [Header("現在HP（開始時は最大でOK）")]
    public int currentHP;

    [Header("HPが0になった時のイベント（エフェクトや消す等）")]
    public UnityEvent onDead;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Max(currentHP, 0);

        if (currentHP <= 0)
        {
            // まずイベント（音・アニメ等）
            onDead?.Invoke();

            // 何もしなければ消すだけ
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }
}

