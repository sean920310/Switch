using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerEntity playerEntity = collision.GetComponent<PlayerEntity>();
            if (playerEntity != null)
            {
                playerEntity?.GetDamage(null, 10.0f);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Border")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
