using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffSystem;

namespace BuffSystem.Model
{
    public abstract class BuffSO : ScriptableObject
    {

        [field: SerializeField]
        private string m_name;

        [field: SerializeField]
        [field: TextArea]
        private string m_description;

        abstract public void ApplyBuff(PlayerEntity playerEntity);
        abstract public void RemoveBuff(PlayerEntity playerEntity);
    }
}
