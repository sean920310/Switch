using BuffSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* Player Event Interface*/
public interface IOnPlayerDamageEvent: IEntityEvent<EntityBase, EntityBase, float> { }
public interface IOnPlayerDamageAction : IEntityAction<EntityBase, EntityBase, float> { }

public interface IOnPlayerAttackEvent : IEntityEvent<EntityBase, EntityBase, float> { }
public interface IOnPlayerAttackAction : IEntityAction<EntityBase, EntityBase, float> { }

public class PlayerEntity : EntityBase
{

    public enum EntityParameter
    {
        health,
        regenerate,
        attack,
        defence,
        speed,
        critRate,
        critDamage,
        cdTime,
        durationTime,
    }

    [SerializeField]
    private float m_critRate;
    [SerializeField]
    private float m_critDamage;
    [SerializeField]
    private float m_switchCDTime;
    [SerializeField]
    private float m_threeDDurationTime;

    [SerializeField]
    private float m_dangerEffectThreshold;

    [Header("Player Event")]

    [RequireInterface(typeof(IOnPlayerDamageEvent))]
    [SerializeField]
    private UnityEngine.Object m_onDamageEventSOObject;

    [RequireInterface(typeof(IOnPlayerAttackEvent))]
    [SerializeField]
    private UnityEngine.Object m_onAttackEventSOObject;

    private IOnPlayerDamageEvent OnDamageEventSO => m_onDamageEventSOObject as IOnPlayerDamageEvent;
    private IOnPlayerAttackEvent OnAttackEventSO => m_onAttackEventSOObject as IOnPlayerAttackEvent;

    [Header("Player UI")]
    [SerializeField] 
    private PlayerHealthBar m_healthBarControl;
    [SerializeField]
    private UserInfo m_infoControl;



    private void OnEnable()
    {
        base.OnEnable();

        CameraManager.Instance.SetSwitchCD(m_switchCDTime);
        CameraManager.Instance.SetDurationTime(m_threeDDurationTime);

        m_infoControl.SetUserInfo(m_attack, m_defence, m_critRate, m_critDamage);
    }

    public override void GetDamage(EntityBase enemyEntity, float damage)
    {
        m_health -= damage;

        if(m_health <= m_dangerEffectThreshold)
        {
            ScreenController.Instance.OnDanger();
        }

        if (m_health <= 0 && !GameManager.Instance.isGameoverTrigger)
        {
            GameManager.Instance.PlayerDead();
            return;
        }

        GetComponent<PlayerStateMachine.PlayerStatesManager>().HurtState();

        m_healthBarControl.SetHealth(m_health/m_initHealth);
        RaiseDamagedEvent(this, enemyEntity, damage);
    }

    public override void SetDamage(EntityBase entity)
    {
        if (!entity) 
            return;
        //Calc damage
        float attack = m_attack * UnityEngine.Random.Range(0.9f, 1.1f);
        float critDamage = UnityEngine.Random.Range(0f, 1f) < m_critRate ? m_critDamage : 0;
        float damage = Mathf.Max((attack - entity.Defence), 0) + critDamage;

        //Set Damage to entity
        entity.GetDamage(this, damage);

        RaiseDamagedEvent(entity, this, damage);
    }

    public void ChangeParameter(EntityParameter entityParameter, float value)
    {
        switch (entityParameter)
        {
            case EntityParameter.health:
                m_health += m_initData.Heath * value;
                if (m_health > m_initHealth) m_health = m_initHealth;
                break;
            case EntityParameter.regenerate:
                break;
            case EntityParameter.attack:
                m_attack += m_attack * value;
                break;
            case EntityParameter.defence:
                m_defence += m_defence * value;
                break;
            case EntityParameter.speed:
                break;
            case EntityParameter.critRate:
                m_critRate += value;
                break;
            case EntityParameter.critDamage:
                m_critDamage += m_critDamage * value;
                break;
            case EntityParameter.cdTime:
                m_switchCDTime -= value;
                CameraManager.Instance.SetSwitchCD(m_switchCDTime);
                break;
            case EntityParameter.durationTime:
                m_threeDDurationTime += value;
                CameraManager.Instance.SetDurationTime(m_threeDDurationTime);
                break;
            default:
                break;
        }
        m_healthBarControl.SetHealth(m_health/m_initHealth);
        m_infoControl.SetUserInfo(m_attack, m_defence, m_critRate, m_critDamage);
    }


    [ContextMenu("TestGetDamage")]
    private void TestGetDamage()
    {
        GetDamage(null, 100);
    }

    public void RaiseDamagedEvent(EntityBase victimEntity, EntityBase enemyEntity, float damage)
    {
        OnDamageEventSO.EntityEvent?.Invoke(victimEntity, enemyEntity, damage);
    }
    public void RaiseAttackEvent(EntityBase victimEntity, EntityBase enemyEntity, float damage)
    {
        OnAttackEventSO.EntityEvent?.Invoke(victimEntity, enemyEntity, damage);


    }
}
