using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player getDamaged.");
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Border")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
