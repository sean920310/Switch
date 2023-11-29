using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSkill : MonoBehaviour
{
    [SerializeField]
    private Image m_countDownMask;

    [SerializeField]
    private Image m_durationMask;

    [SerializeField]
    private Animator m_skillResetAnimator;

    [SerializeField, ReadOnly]
    private float m_remainTime = 0;

    [SerializeField]
    private Text m_timeText;

    private float m_countDownTime = -1;
    private bool m_isCountDown = false;

    private float m_durationTime = -1;
    private bool m_isDuration = false;

    private bool m_isAppQuiting = false;


    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += OnSwitch;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_countDownTime = CameraManager.Instance.GetSwitchCD();
        m_durationTime = CameraManager.Instance.GetDurationTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isCountDown)
        {
            m_remainTime -= Time.deltaTime;
            m_timeText.text = ((int)m_remainTime).ToString();

            if (m_remainTime <= 0)
            {
                m_remainTime = 0;
                m_timeText.text = "";
                m_isCountDown = false;
                m_skillResetAnimator.Play("SkillReset");
            }

            m_countDownMask.fillAmount = m_remainTime / m_countDownTime;
        }

        if (m_isDuration)
        {
            m_remainTime -= Time.deltaTime;

            if (m_remainTime <= 0)
            {
                m_remainTime = 0;
                m_isDuration = false;
            }

            m_durationMask.fillAmount = m_remainTime / m_durationTime;
        }

    }

    private void OnSwitch(CameraManager.Dimension state)
    {
        if (state == CameraManager.Dimension.ThreeD)
        {
            m_durationTime = CameraManager.Instance.GetDurationTime();
            if (m_durationTime <= 0) return;
            m_remainTime = m_durationTime;
            m_isDuration = true;
            m_isCountDown = false;
            m_countDownMask.fillAmount = 0;
        }
        else
        {
            m_countDownTime = CameraManager.Instance.GetSwitchCD();
            if (m_countDownTime <= 0) return;
            m_remainTime = m_countDownTime;
            m_isCountDown = true;
            m_isDuration = false;
            m_durationMask.fillAmount = 0;
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
