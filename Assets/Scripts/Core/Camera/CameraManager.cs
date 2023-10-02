using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : PersistentSingleton<CameraManager>
{
    public delegate void CameraSwitchDelegate(Dimension state);
    public event CameraSwitchDelegate OnSwitchCallback;

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

    /// <summary>
    /// Switch Dimension State
    /// </summary>
    public void Switch()
    {
        if (Instance.m_dimensionState == Dimension.TwoD)
            Instance.m_dimensionState = Dimension.ThreeD;
        else
            Instance.m_dimensionState = Dimension.TwoD;

        OnSwitchCallback?.Invoke(Instance.m_dimensionState);
    }

    /// <summary>
    /// Switch Dimension State
    /// </summary>
    /// <param name="state">State to Switch</param>
    public void Switch(Dimension state)
    {
        Instance.m_dimensionState = state;

        OnSwitchCallback?.Invoke(Instance.m_dimensionState);
    }
}
