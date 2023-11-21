using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGhoulEntity : EntityBase
{
    [SerializeField] private GameObject m_deathExplosion;
    [SerializeField] private HealthBarControl m_healthBarControl;

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
            Instantiate(m_deathExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        m_healthBarControl.SetHealth(m_health / m_initHealth);
        GetComponent<BurningGhoulStateManager>().HurtState();
    }

    public override void SetDamage(EntityBase entity)
    {
        if (!entity)
            return;
        //Calc damage
        float attack = m_attack * Random.Range(0.9f, 1.1f);
        float damage = Mathf.Max((attack - entity.Defence), 0);

        //Set Damage to entity
        entity.GetDamage(this, damage);
    }
}
