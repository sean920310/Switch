using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    [SerializeField]
    private GameObject m_healthBarObj;

    [SerializeField]
    private Image m_healthBar;

    private bool m_isAppQuiting = false;

    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += OnSwitch;
    }


    // Start is called before the first frame update
    void Start()
    {
        SetHealthBarActive(true);
        SetHealth(1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
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

    public void SetHealthBarActive(bool active)
    {
        m_healthBarObj.SetActive(active);
    }

    public void SetHealth(float health)
    {
        m_healthBar.fillAmount = health;
    }

    void OnSwitch(CameraManager.Dimension state)
    {
        if(state == CameraManager.Dimension.ThreeD)
        {
            SetHealthBarActive(false);
        }
        else
        {
            SetHealthBarActive(true);
        }
    }
}
