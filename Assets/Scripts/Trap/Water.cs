using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    GameObject waterFall;
    GameObject river;
    GameObject grandChild;
    Vector3 default_pos;
    Vector3 river_default;
    float timer = 0;
    ParticleSystem water_particle;
    ParticleSystem.MainModule particle_main;

    private void Start()
    {
        waterFall = transform.Find("WaterFall2").gameObject;
        river = transform.Find("RiverSet").gameObject;
        grandChild = transform.Find("WaterFall2/Particle System").gameObject;
        water_particle = waterFall.GetComponent<ParticleSystem>();
        particle_main = water_particle.main;
        default_pos = waterFall.transform.localPosition;
        river_default = river.transform.localPosition;
        waterFall.SetActive(true);
        river.SetActive(true);
        timer = 0;
    }

    // Update is called once per frame
    private void Update()
     {
         if (CameraManager.Instance.DimensionState == CameraManager.Dimension.ThreeD)
         {
            grandChild.SetActive(false);

            Vector3 river_current = river.transform.localPosition;
            Vector3 river_target = new Vector3(0, 0.6f, 0);

            Vector3 current = default_pos;
            Vector3 target = new Vector3(0, 4.7f, -0.5f);
            particle_main.startLifetime = 0.45f;
            waterFall.transform.localRotation = new Quaternion(-17.5f, 0, 0, 0);
            waterFall.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);

            timer += Time.deltaTime * 0.5f;
            river.transform.localPosition = Vector3.Lerp(river_current, river_target, timer);
            waterFall.transform.localPosition = Vector3.Lerp(current, target, timer);

            //waterFall.SetActive(false);
            //river.SetActive(true);
        }
         else
         {
            timer = 0;
            grandChild.SetActive(true);
            //waterFall.SetActive(true);
            waterFall.transform.localRotation = new Quaternion(-30f, 0, 0, 0);
            waterFall.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            particle_main.startLifetime = 1.5f;
            waterFall.transform.localPosition = default_pos;
            river.transform.localPosition = river_default;
        }
    }
}
