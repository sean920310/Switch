using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace BuffSystem.Model
{

    [CreateAssetMenu(fileName = "NewBuffData", menuName = "Buff/Create FunctionalBuff Data")]
    public class FunctionalBuffSO : BuffSO
    {

        [RequireInterface(typeof(IOnPlayerDamageEvent))]
        [SerializeField]
        private UnityEngine.Object m_onDamageEventSOObject;

        [RequireInterface(typeof(IOnPlayerDamageAction))]
        [SerializeField]
        private UnityEngine.Object m_onDamageActionObject;

        private IOnPlayerDamageEvent OnDamageEventSO => m_onDamageEventSOObject as IOnPlayerDamageEvent;
        private IOnPlayerDamageAction OnDamageAction => m_onDamageActionObject as IOnPlayerDamageAction;

        override public void ApplyBuff(PlayerEntity playerEntity)
        {
            if(m_onDamageEventSOObject != null && OnDamageAction != null)
                OnDamageEventSO.EntityEvent.AddListener(OnDamageAction.EntityAction);
        }

        override public void RemoveBuff(PlayerEntity playerEntity)
        {
            if (m_onDamageEventSOObject != null && OnDamageAction != null)
                OnDamageEventSO.EntityEvent.RemoveListener(OnDamageAction.EntityAction);
        }
    }
}
