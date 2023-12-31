using System.Collections;
using System.Collections.Generic;
using BuffSystem.Model;
using Unity.VisualScripting;
using UnityEngine;

public class BuffCards : MonoBehaviour
{
    public enum BuffIcon
    {
        SWORD,
        SHEILD,
        CLOCK,
        HOURGLASS
    }

    public Animator anim;
    public BuffCard[] cards;
    public Sprite[] cardBG;
    public Sprite[] cardIcon;

    public delegate void OnBuffClicked(int cardIdx);
    public event OnBuffClicked onBuffClicked;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     Debug.Log("Card_Show");
        //     anim.Play("Card_Show");
        //     SetBuffCard(0, "!", BuffIcon.SWORD);
        //     SetBuffCard(1, "!", BuffIcon.CLOCK);
        //     SetBuffCard(2, "!", BuffIcon.HOURGLASS);
        // }

        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     Debug.Log("Card_Hide");
        //     anim.Play("Card_Hide");
        // }
    }

    /*
    cardIdx: 0~2
    type: 0是劍 1是盾
    */
    public void SetBuffCard(int cardIdx, string descriptions, BuffIcon type/*, BuffSystem.Model.BuffSO buffSO = null*/)
    {
        // cardIdx.ToString() 需替換成文字內容
        cards[cardIdx].SetBuffCard(descriptions, cardBG[((int)type)], cardIcon[((int)type)]);
    }

    public void BuffCardClick(int cardIdx)
    {
        onBuffClicked?.Invoke(cardIdx);
    }
}
