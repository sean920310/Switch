using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    ParticleSystem RedFire;
    ParticleSystem OrangeFire;
    ParticleSystem YellowFire;

    ParticleSystem.MainModule RedFire_main;
    ParticleSystem.MainModule OrangeFire_main;
    ParticleSystem.MainModule YellowFire_main;

    BoxCollider2D myCollider;

    [SerializeField]
    float fire_height;

    private void Start()
    {
        RedFire = transform.Find("FireTrap/RedFire").gameObject.GetComponent<ParticleSystem>();
        OrangeFire = transform.Find("FireTrap/OrangeFire").gameObject.GetComponent<ParticleSystem>();
        YellowFire = transform.Find("FireTrap/YellowFire").gameObject.GetComponent<ParticleSystem>();

        RedFire_main = RedFire.main;
        OrangeFire_main = OrangeFire.main;
        YellowFire_main = YellowFire.main;

        myCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Setting value
        myCollider.size = new Vector2(0.5f, fire_height);
        RedFire_main.startLifetime = 1.4f * fire_height;
        OrangeFire_main.startLifetime = 1f * fire_height;
        YellowFire_main.startLifetime = 0.7f * fire_height;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player gets damaged.");
        }
    }
}
