using System.Collections.Generic;
using UnityEngine;

public class ValueSetter : MonoBehaviour
{
    [SerializeField] private NumberTextComponent killsCount;

    void Start()
    {
        // �V�[�����ׂ��ł����l�������ő�����܂�

        killsCount.InitalSetValue(ScoreManager.Instance.GetKillNum());
    }
}
