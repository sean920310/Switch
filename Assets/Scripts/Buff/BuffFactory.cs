using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NestedEnum;
using BuffSystem.Model;

namespace BuffSystem
{
    public class BuffFactory : MonoBehaviour
    {
        [SerializeField] private Dictionary<ID, BuffSO> m_buffDict;
        [SerializeField] private BuffSO[] m_defendBuffList;


        void Start()
        {
            m_buffDict.Add(BuffType.GOD_OF_DEFENDS.DEFENSE_INCREASE, m_defendBuffList[0]);
        }

        public BuffSO GetBuffByID(ID buffId)
        {
            return m_buffDict[buffId];
        }

    }

}
