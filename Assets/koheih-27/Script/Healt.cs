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
    [SerializeField]
    public int maxHP = 5;

    [Header("現在HP（開始時は最大でOK）")]
    [SerializeField]
    public int currentHP;

    [Header("HPが0になった時のイベント（エフェクトや消す等）")]
    public UnityEvent onDead;

    void Awake()
    {
        currentHP = maxHP;
    }
    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }
}

