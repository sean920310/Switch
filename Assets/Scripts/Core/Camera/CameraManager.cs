using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : PersistentSingleton<CameraManager>
{
    public delegate void CameraSwitchDelegate(Dimension state);
    public event CameraSwitchDelegate OnSwitchCallback;

    private float m_CDTime;
    private float m_durationTime;
    private bool m_canSwitch = true;

    public enum Dimension
    {
        TwoD,
        ThreeD
    }

    private Dimension m_dimensionState = Dimension.TwoD;

    public Dimension DimensionState { get => m_dimensionState; }


    void Start()
    {
        Switch(Dimension.TwoD);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Switch();
        }
    }

    public void SetSwitchCD(float time)
    {
        m_CDTime = time;
    }

    public void SeDurationTime(float time)
    {
        m_durationTime = time;
    }

    public float GetSwitchCD()
    {
        return m_CDTime;
    }

    /// <summary>
    /// Switch Dimension State
    /// </summary>
    public void Switch()
    {
        if(m_canSwitch)
        {
            if (Instance.m_dimensionState == Dimension.TwoD)
                Instance.m_dimensionState = Dimension.ThreeD;
            else
                Instance.m_dimensionState = Dimension.TwoD;

            OnSwitchCallback?.Invoke(Instance.m_dimensionState);

            if(Instance.m_dimensionState == Dimension.TwoD)
                StartCoroutine(SwitchCDLock());
            else
                StartCoroutine(ForceSwitchBack());
        }
    }

    /// <summary>
    /// Switch Dimension State
    /// </summary>
    /// <param name="state">State to Switch</param>
    public void Switch(Dimension state)
    {
        Instance.m_dimensionState = state;

        OnSwitchCallback?.Invoke(Instance.m_dimensionState);
        if (Instance.m_dimensionState == Dimension.TwoD)
            StartCoroutine(SwitchCDLock());
        else
            StartCoroutine(ForceSwitchBack());
    }

    private IEnumerator SwitchCDLock()
    {
        m_canSwitch = false;
        yield return new WaitForSeconds(m_CDTime);
        m_canSwitch = true;
    }

    private IEnumerator ForceSwitchBack()
    {
        yield return new WaitForSeconds(m_durationTime);
        if (Instance.DimensionState == Dimension.ThreeD)
            Switch(Dimension.TwoD);
    }
}
