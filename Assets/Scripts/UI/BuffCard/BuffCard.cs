using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCard : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Card_Show");
            anim.Play("Card_Show");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Card_Hide");
            anim.Play("Card_Hide");
        }
    }
}
