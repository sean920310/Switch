using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem.Model
{
    [System.Serializable]
    public class BuffParameter
    {
        [SerializeField] private PlayerEntity.EntityParameter m_entityParameter;
        [SerializeField] private float m_value;

        public PlayerEntity.EntityParameter entityParameter { get => m_entityParameter; }
        public float value { get => m_value; }
    }

    [CreateAssetMenu(fileName = "NewBuffData", menuName = "Buff/Create ParameterBuffSO Data")]
    public class ParameterBuffSO : BuffSO
    {
        
        [SerializeField] private List<BuffParameter> m_entityParameterList;

        override public void ApplyBuff(PlayerEntity playerEntity)
        {
            m_entityParameterList.ForEach(parameter =>
            {
                playerEntity.ChangeParameter(parameter.entityParameter, parameter.value);
            });
        }

        override public void RemoveBuff(PlayerEntity playerEntity)
        {
            m_entityParameterList.ForEach(parameter =>
            {
                playerEntity.ChangeParameter(parameter.entityParameter, -parameter.value);
            });
        }

    }
}
