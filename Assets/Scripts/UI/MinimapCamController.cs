using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamController : MonoBehaviour
{
    [SerializeField] private Shader minimapShader;
    [SerializeField] private Transform player;

    void Start()
    {
        GetComponent<Camera>().SetReplacementShader(minimapShader, "");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
