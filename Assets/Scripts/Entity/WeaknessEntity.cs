using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaknessEntity : EntityBase
{
    [Header("Sound")]
    [SerializeField]
    private AudioSource m_weaknessBreak;

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
        if (m_health <= 0)
        {
            m_weaknessBreak?.Play();
            Destroy(gameObject);
        }
    }

    public override void SetDamage(EntityBase entity)
    {
    }
}
