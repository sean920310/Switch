using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    [SerializeField] private Text m_attack;
    [SerializeField] private Text m_defence;
    [SerializeField] private Text m_critRate;
    [SerializeField] private Text m_critDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUserInfo(float attack, float defence, float critRate, float critDamage)
    {
        m_attack.text = ((int)attack).ToString();
        m_defence.text = ((int)defence).ToString();
        m_critRate.text = ((int)(critRate * 100f)).ToString() + '%';
        m_critDamage.text = ((int)critDamage).ToString();
    }
}
