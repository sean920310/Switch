using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem.Model
{
    [CreateAssetMenu(fileName = "NewBuffData", menuName = "Buff/Create ParameterBuffSO Data")]
    public class ParameterBuffSO : BuffSO
    {
        [SerializeField] private PlayerEntity.EntityParameter m_entityParameter;
        [SerializeField] private float value;

        override public void ApplyBuff(PlayerEntity playerEntity)
        {
            playerEntity.ChangeParameter(m_entityParameter, value);
        }

        override public void RemoveBuff(PlayerEntity playerEntity)
        {
            playerEntity.ChangeParameter(m_entityParameter, -value);
        }

    }
}
