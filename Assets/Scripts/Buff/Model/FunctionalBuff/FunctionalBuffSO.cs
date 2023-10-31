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

        [RequireInterface(typeof(IOnPlayerAttackEvent))]
        [SerializeField]
        private UnityEngine.Object m_onAttackEventSOObject;

        [RequireInterface(typeof(IOnPlayerAttackAction))]
        [SerializeField]
        private UnityEngine.Object m_onAttackActionObject;

        private IOnPlayerDamageEvent OnDamageEventSO => m_onDamageEventSOObject as IOnPlayerDamageEvent;
        private IOnPlayerDamageAction OnDamageAction => m_onDamageActionObject as IOnPlayerDamageAction;

        private IOnPlayerAttackEvent OnAttackEventSO => m_onAttackEventSOObject as IOnPlayerAttackEvent;
        private IOnPlayerAttackAction OnAttackAction => m_onAttackActionObject as IOnPlayerAttackAction;

        override public void ApplyBuff(PlayerEntity playerEntity)
        {
            if(m_onDamageEventSOObject != null && OnDamageAction != null)
                OnDamageEventSO.EntityEvent.AddListener(OnDamageAction.EntityAction);

            if (m_onAttackEventSOObject != null && OnAttackAction != null)
                OnAttackEventSO.EntityEvent.AddListener(OnAttackAction.EntityAction);
        }

        override public void RemoveBuff(PlayerEntity playerEntity)
        {
            if (m_onDamageEventSOObject != null && OnDamageAction != null)
                OnDamageEventSO.EntityEvent.RemoveListener(OnDamageAction.EntityAction);

            if (m_onAttackEventSOObject != null && OnAttackAction != null)
                OnAttackEventSO.EntityEvent.RemoveListener(OnAttackAction.EntityAction);
        }
    }
}
