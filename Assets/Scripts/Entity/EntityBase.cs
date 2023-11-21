using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class EntityBase : MonoBehaviour
{

    [SerializeField]
    protected EntityData m_initData = null;

    [SerializeField] protected float m_initHealth;
    [SerializeField] protected float m_health; 
    [SerializeField] protected float m_regenerate; 
    [SerializeField] protected float m_attack; 
    [SerializeField] protected float m_defence;
    [SerializeField] protected float m_speed;

    public float InitHealth { get => m_initHealth; }
    public float Health { get => m_health; }
    public float Regenerate { get => m_regenerate; }
    public float Attack { get => m_attack; }
    public float Defence { get => m_defence; }
    public float Speed { get => m_speed; }

    protected void OnEnable()
    {
        if (m_initData != null)
        {
            m_initHealth = m_initData.Heath;
            m_health = m_initData.Heath;
            m_regenerate = m_initData.Regenerate;
            m_attack = m_initData.Attack;
            m_defence = m_initData.Defence;
            m_speed = m_initData.Speed;
        }
        else
            Debug.LogError("EntityBase missing m_initData");
    }

    abstract public void GetDamage(EntityBase enemyEntity, float damage);
    abstract public void SetDamage(EntityBase entity);
}


/// <summary>
/// IEntityEvent: Handle the event of Entity.
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
[SerializeField]
public interface IEntityEvent<T1, T2, T3>
{
    [Serializable] public class OnEntityEvent : UnityEvent<T1, T2, T3> { }
    [SerializeField] public OnEntityEvent EntityEvent { get;}
    public void RaiseEntityEvent(T1 t1, T2 t2, T3 t3);
}

/// <summary>
/// IEntityEvent: The action that entity raise event.
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
[SerializeField]
public interface IEntityAction<T1, T2, T3>
{
    public void EntityAction(T1 t1, T2 t2, T3 t3);
}