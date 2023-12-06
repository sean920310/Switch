using System.Collections;
using System.Collections.Generic;
using BuffSystem.Model;
using Unity.VisualScripting;
using UnityEngine;

public class BuffCards : MonoBehaviour
{
    public Animator anim;
    public BuffCard[] cards;
    public Sprite[] cardBG;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Card_Show");
            anim.Play("Card_Show");
            SetBuffCard(0, 0, ScriptableObject.CreateInstance<BuffSO>());
            SetBuffCard(1, 1, ScriptableObject.CreateInstance<BuffSO>());
            SetBuffCard(2, 0, ScriptableObject.CreateInstance<BuffSO>());
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Card_Hide");
            anim.Play("Card_Hide");
        }
    }

    public void SetBuffCard(int cardIdx, int type, BuffSystem.Model.BuffSO buffSO)
    {
        cards[cardIdx].SetBuffCard(cardIdx.ToString(), cardBG[type]);
    }

    public void BuffCardClick(int cardIdx)
    {
        Debug.Log("BuffCard_Clicked: " + cardIdx);
    }
}
