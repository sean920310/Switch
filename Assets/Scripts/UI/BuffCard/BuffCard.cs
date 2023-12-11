using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffCard : MonoBehaviour
{
    public TextMeshProUGUI description;
    public Image bg;
    public Image icon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBuffCard(string text, Sprite bgSprite, Sprite iconSprite)
    {
        description.text = text;
        bg.sprite = bgSprite;
        icon.sprite = iconSprite;
    }
}
