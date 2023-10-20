using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffSystem;

namespace BuffSystem.Model
{
    public abstract class BuffSO : ScriptableObject
    {
        [SerializeField] protected BuffBase m_buffBase;
    }
}
