using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderSwitch : MonoBehaviour
{
    [SerializeField]
    public float colliderSize3D_x = 0.3779367f;
    [SerializeField]
    public float colliderSize3D_y = 0.69f;
    [SerializeField]
    public float colliderOffset3D_x = 0.1072523f;
    [SerializeField]
    public float colliderOffset3D_y = -0.72f;
    [SerializeField]
    private GameObject camTarget;

    // Update is called once per frame
    private void LateUpdate()
    {
        if (CameraManager.Instance.DimensionState == CameraManager.Dimension.ThreeD)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(colliderSize3D_x, colliderSize3D_y);
            GetComponent<BoxCollider2D>().offset = new Vector2(colliderOffset3D_x, colliderOffset3D_y);
            camTarget.transform.localPosition = new Vector3(0f, 1.403f, -0.6f);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.3779367f, 1.591878f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0.1072523f, 0.005540371f);
            camTarget.transform.localPosition = new Vector3(0f, 1.403f, 0f);
        }
    }
}
