using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skill[] skills;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            skills[0].PressKeyBoard();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            skills[1].PressKeyBoard();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            skills[2].PressKeyBoard();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            skills[3].PressKeyBoard();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            skills[4].PressKeyBoard();
        }
    }
}
