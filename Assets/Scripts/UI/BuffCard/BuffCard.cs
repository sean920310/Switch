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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBuffCard(string text, Sprite sprite)
    {
        description.text = text;
        bg.sprite = sprite;
    }
}
