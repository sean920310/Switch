using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    [SerializeField]
    private float m_critRate;
    private float m_critDamage;

    public delegate void OnDamageDelegate(EntityBase entityBasek, float damage);
    public event OnDamageDelegate OnDamageCallback;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GetDamage(EntityBase enemyEntity, float damage)
    {
        m_health -= damage;

        OnDamageCallback?.Invoke(enemyEntity, damage);
    }

    public override void SetDamage(EntityBase entity)
    {
        //Calc damage
        float attack = m_attack * Random.Range(0.9f, 1.1f);
        float critDamage = Random.Range(0f, 1f) < m_critRate ? m_critDamage : 0;
        float damage = Mathf.Max((attack - entity.Defence), 0) + critDamage;

        //Set Damage to entity
        entity.GetDamage(this, damage);
    }

    public void ChangeParameter(EntityParameter entityParameter, float value)
    {
        switch (entityParameter)
        {
            case EntityParameter.health:

                break;
            case EntityParameter.regenerate:
                break;
            case EntityParameter.attack:
                m_attack += m_attack * value;
                break;
            case EntityParameter.defence:
                break;
            case EntityParameter.speed:
                break;
            case EntityParameter.critRate:
                break;
            case EntityParameter.critDamage:
                break;
            default:
                break;
        }
    }

}
