using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffSystem;

namespace BuffSystem.Model
{
    public abstract class BuffSO : ScriptableObject
    {
        [field:SerializeField] public BuffBase m_buffBase;

        abstract public void ApplyBuff(PlayerEntity playerEntity);
        abstract public void RemoveBuff(PlayerEntity playerEntity);
    }
}
