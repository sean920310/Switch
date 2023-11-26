using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    [SerializeField] public LayerMask whatIsPlayer;
    [SerializeField] public LayerMask borderLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatIsPlayer & (1 << collision.gameObject.layer)) != 0)
        {
            PlayerEntity playerEntity = collision.GetComponent<PlayerEntity>();
            if (playerEntity != null)
            {
                playerEntity?.GetDamage(null, 10.0f);
            }
            Destroy(gameObject);
        }
        else if ((borderLayer & (1 << collision.gameObject.layer)) != 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
