using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace BuffSystem.Model
{

    [SerializeField]
    public interface IOnDamageAction
    {
        [Serializable] public class OnDamageEvent : UnityEvent<EntityBase, EntityBase, float> { }
        [SerializeField] public OnDamageEvent PlayerOnDamageEvent { get; set; }
        public void RaiseDamageEvent(EntityBase victimEntity, EntityBase enemyEntity, float value);
    }

    [SerializeField]
    public interface IDamageEvent
    {
        public void DamageEvent(EntityBase victimEntity, EntityBase enemyEntity, float value);
    }

    [CreateAssetMenu(fileName = "NewBuffData", menuName = "Buff/Create FunctionalBuff Data")]
    public class FunctionalBuffSO : BuffSO
    {

        [RequireInterface(typeof(IOnDamageAction))]
        [SerializeField]
        private UnityEngine.Object m_onDamageSO;

        [RequireInterface(typeof(IDamageEvent))]
        [SerializeField]
        private UnityEngine.Object m_onDamageEvent;

        private IOnDamageAction onDamageSO => m_onDamageSO as IOnDamageAction;
        private IDamageEvent onDamageEvent => m_onDamageEvent as IDamageEvent;

        override public void ApplyBuff(PlayerEntity playerEntity)
        {
            onDamageSO.PlayerOnDamageEvent.AddListener(onDamageEvent.DamageEvent);
        }

        override public void RemoveBuff(PlayerEntity playerEntity)
        {
            onDamageSO.PlayerOnDamageEvent.RemoveListener(onDamageEvent.DamageEvent);
        }
    }
}
