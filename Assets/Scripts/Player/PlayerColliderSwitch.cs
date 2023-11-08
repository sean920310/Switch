using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderSwitch : MonoBehaviour
{
    [SerializeField]
    public float colliderSize3D_x = 0.3779367f;
    [SerializeField]
    public float colliderSize3D_y = 0.7923383f;

    // Update is called once per frame
    private void LateUpdate()
    {
        if (CameraManager.Instance.DimensionState == CameraManager.Dimension.ThreeD)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(colliderSize3D_x, colliderSize3D_y);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.3779367f, 1.591878f);
        }
    }
}
