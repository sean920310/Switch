using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float arrowSpeed = 10.0f;
    [SerializeField] float setWaittingTime = 1.0f;
    [SerializeField] float setDelayTime = 1.0f;
    [SerializeField, ReadOnly] float countDown;
    [SerializeField, ReadOnly] float delay;
    [SerializeField] float suicideTime = 1.0f;
    public Transform shotPoint;

    private void Start()
    {
        countDown = setWaittingTime;
        delay = setDelayTime;
    }

    void Update()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Shot();
                countDown = setWaittingTime;
            }
        }
        
    }

    void Shot()
    {
        GameObject shotObj = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        Destroy(shotObj, suicideTime);
        shotObj.GetComponent<Rigidbody2D>().velocity = shotObj.transform.up * arrowSpeed;
    }
}
