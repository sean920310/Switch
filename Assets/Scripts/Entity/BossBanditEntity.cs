using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBanditEntity: EntityBase
{
    [SerializeField] private GameObject m_deathExplosion;
    [SerializeField] private HealthBarControl m_healthBarControl;
    [SerializeField] private WeaknessController m_weaknessController;
    [SerializeField] private AudioClip m_deadSound;

    private bool m_hasShell = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_hasShell && !m_weaknessController.HasWeakness())
        {
            GetComponent<BossBanditStateManager>().SetShellBreak();
            m_hasShell = false;
        }

    }

    public override void GetDamage(EntityBase enemyEntity, float damage)
    {
        if (m_weaknessController.HasWeakness())
            return;
        m_health -= damage;
        if (m_health <= 0)
        {
            Instantiate(m_deathExplosion, transform.position, transform.rotation);
            AudioManager.Instance.PlayOnShot(m_deadSound);
            Destroy(gameObject);
        }
        m_healthBarControl.SetHealth(m_health / m_initHealth);
        GetComponent<BossBanditStateManager>().HurtState();
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
