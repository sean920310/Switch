using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLosePanel : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("GameLosePanel_Show");
            anim.Play("GameLosePanel_Show");
        }
    }
}
