using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EntityBase : MonoBehaviour
{
    protected float m_heath; 
    protected float m_regenerate; 
    protected float m_attack; 
    protected float m_defence; 
    protected float m_speed;

    public float Heath { get => m_heath; }
    public float Regenerate { get => m_heath; }
    public float Attack { get => m_attack; }
    public float Defence { get => m_defence; }
    public float Speed { get => m_speed; }

    abstract public void GetDamage(float damage);
    abstract public void SetDamage(EntityBase entity);
}
