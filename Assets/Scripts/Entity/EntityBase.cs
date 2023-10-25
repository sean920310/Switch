using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EntityBase : MonoBehaviour
{

    [SerializeField]
    protected EntityData m_initData = null;

    [SerializeField] protected float m_health; 
    [SerializeField] protected float m_regenerate; 
    [SerializeField] protected float m_attack; 
    [SerializeField] protected float m_defence;
    [SerializeField] protected float m_speed;

    public float Health { get => m_health; }
    public float Regenerate { get => m_regenerate; }
    public float Attack { get => m_attack; }
    public float Defence { get => m_defence; }
    public float Speed { get => m_speed; }

    private void OnEnable()
    {
        if (m_initData != null)
        {
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
