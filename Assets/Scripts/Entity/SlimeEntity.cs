using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEntity : EntityBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GetDamage(float damage)
    {
        m_heath -= damage;
    }

    public override void SetDamage(EntityBase entity)
    {
        //Calc damage
        float attack = m_attack * Random.Range(0.9f, 1.1f);
        float damage = Mathf.Max((attack - entity.Defence), 0);

        //Set Damage to entity
        entity.GetDamage(damage);
    }
}
