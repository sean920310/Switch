using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : EntityBase
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
        entity.GetDamage(m_attack);
    }
}
