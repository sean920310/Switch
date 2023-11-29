using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : TrapBase
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
    [SerializeField, ReadOnly]
    float newOffset_y = 0;

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
        newOffset_y = 0.5f * (fire_height - 1f);
        myCollider.offset = new Vector2(0, newOffset_y);
        RedFire_main.startLifetime = 1.2f * fire_height;
        OrangeFire_main.startLifetime = 1f * fire_height;
        YellowFire_main.startLifetime = 0.7f * fire_height;
    }

}
