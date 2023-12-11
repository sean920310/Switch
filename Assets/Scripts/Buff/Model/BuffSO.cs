using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffSystem;
using Unity.VisualScripting;

namespace BuffSystem.Model
{
    public abstract class BuffSO : ScriptableObject
    {
        [field: SerializeField]
        public BuffCards.BuffIcon buffIcon;

        [field: SerializeField]
        public string buffName;

        [field: SerializeField]
        [field: TextArea]
        public string description;

        abstract public void ApplyBuff(PlayerEntity playerEntity);
        abstract public void RemoveBuff(PlayerEntity playerEntity);
    }
}
