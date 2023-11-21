using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSkill : MonoBehaviour
{
    [SerializeField]
    private Image m_countDownMask;

    [SerializeField, ReadOnly]
    private float m_remainTime = 0;

    [SerializeField]
    private Text m_timeText;

    private float m_countDownTime = -1;
    private bool m_isCounting = false;

    private bool m_isAppQuiting = false;


    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += OnSwitch;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_countDownTime = CameraManager.Instance.GetSwitchCD();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isCounting)
        {
            m_remainTime -= Time.deltaTime;
            m_timeText.text = ((int)m_remainTime).ToString();

            if (m_remainTime <= 0)
            {
                m_remainTime = 0;
                m_timeText.text = "";
                m_isCounting = false;
            }

            m_countDownMask.fillAmount = m_remainTime / m_countDownTime;
        }
        
    }

    private void OnSwitch(CameraManager.Dimension state)
    {
        if(state == CameraManager.Dimension.ThreeD)
        {

        }
        else
        {
            if (m_countDownTime < 0) return;
            m_remainTime = m_countDownTime;
            m_isCounting = true;
        }
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

    private void OnDisable()
    {
        if (!m_isAppQuiting)
            CameraManager.Instance.OnSwitchCallback -= OnSwitch;
    }
}
