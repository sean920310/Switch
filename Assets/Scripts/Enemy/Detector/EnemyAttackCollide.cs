using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollide : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            Debug.Log("Player Hurt: " + collision.gameObject.name);
            gameObject.GetComponentInParent<EntityBase>().SetDamage(collision.gameObject.GetComponent<EntityBase>());
            this.enabled = false;
        }
    }
}
