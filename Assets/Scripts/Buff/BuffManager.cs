using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffSystem.Model;
using System;
using NestedEnum;

namespace BuffSystem
{
    public class BuffManager : MonoBehaviour
    {
        [SerializeField] private List<BuffSO> m_buffList;
        private BuffFactory m_buffFactory;
        private PlayerEntity m_playerEntity;

        [SerializeField] private BuffSO m_buffSOCheatBox;

        private void Start()
        {
            m_playerEntity = GetComponent<PlayerEntity>();
        }
        public BuffSO AddBuff(BuffSO buff)
        {
            if (buff == null)
            {
                return null;
            }

            m_buffList.Add(buff);

            buff.ApplyBuff(m_playerEntity);

            return buff;
        }

        public BuffSO AddBuff(ID buffType)
        {
            BuffSO tempBuffSO = m_buffFactory.GetBuffByID(buffType);

            if (tempBuffSO == null)
            {
                return null;
            }

            m_buffList.Add(tempBuffSO);

            tempBuffSO.ApplyBuff(m_playerEntity);

            return tempBuffSO;
        }

        public void RemoveBuff(ID buffType)
        {
            BuffSO tempBuffSO = m_buffFactory.GetBuffByID(buffType);
            int buffIdx = m_buffList.IndexOf(tempBuffSO);
            if (buffIdx != -1)
            {
                m_buffList.RemoveAt(buffIdx);
                tempBuffSO.RemoveBuff(m_playerEntity);
            }
        }

        public void RemoveBuff(BuffSO buffData)
        {
            int buffIdx = m_buffList.IndexOf(buffData);
            if (buffIdx != -1)
            {
                m_buffList.RemoveAt(buffIdx);
                buffData.RemoveBuff(m_playerEntity);
            }
        }

        /* Cheating Section*/
        [ContextMenu("Buff Cheat Add")]
        public void BuffSOCheatAdd()
        {
            if (m_buffSOCheatBox == null)
            {
                return;
            }
            AddBuff(m_buffSOCheatBox);
        }

        [ContextMenu("Buff Cheat Remove")]
        public void BuffSOCheatRemove()
        {
            if (m_buffSOCheatBox == null)
            {
                return;
            }
            RemoveBuff(m_buffSOCheatBox);
        }



        private void OnGUI()
        {
            if (GUILayout.Button("Buff Cheat Add"))
            {
                BuffSOCheatAdd();
            }
            if (GUILayout.Button("Buff Cheat Remove"))
            {
                BuffSOCheatRemove();
            }
        }
    }
}
