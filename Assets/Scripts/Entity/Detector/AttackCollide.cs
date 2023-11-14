using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollide : MonoBehaviour
{
    [SerializeField] LayerMask detectLayer;

    private bool m_collided = false;

    private void OnEnable()
    {
        m_collided = false;
    }

    private void OnDisable()
    {
        m_collided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_collided)
            return;
        if ((detectLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            Debug.Log("Entity Hurt: " + collision.gameObject.name);
            gameObject.GetComponentInParent<EntityBase>()?.SetDamage(collision.gameObject.GetComponent<EntityBase>());
            m_collided = true;
        }
    }

}
