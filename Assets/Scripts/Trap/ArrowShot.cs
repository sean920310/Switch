using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float arrowSpeed = 10.0f;
    [SerializeField] float setWaittingTime = 1.0f;
    [SerializeField, ReadOnly] float countDown;
    [SerializeField] float suicideTime = 1.0f;
    public Transform shotPoint;

    private void Start()
    {
        countDown = setWaittingTime;
    }

    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            Shot();
            countDown = setWaittingTime;
        }
    }

    void Shot()
    {
        GameObject shotObj = Instantiate(arrow, shotPoint.position, Quaternion.identity);
        Destroy(shotObj, suicideTime);
        shotObj.GetComponent<Rigidbody2D>().velocity = transform.right * arrowSpeed;
    }
}
