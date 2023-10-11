using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBillboard : MonoBehaviour
{
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void LateUpdate()
    {
        float oldRotationY = transform.rotation.eulerAngles.y;
        Vector3 newRotation = mainCamera.transform.eulerAngles;
        //newRotation.x = 0;
        //newRotation.z = 0;
        newRotation.y = oldRotationY;
        transform.eulerAngles = newRotation;
    }
}
