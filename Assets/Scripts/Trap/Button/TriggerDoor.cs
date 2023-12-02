using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public enum DoorState
    {
        Close,
        Open
    }
    [SerializeField] float m_openShift;
    [SerializeField] DoorState m_buttonState = DoorState.Close;

    [SerializeField] Switch m_LinkButton;

    private bool m_isAppQuiting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        if (!m_isAppQuiting && m_LinkButton)
        {
            m_LinkButton.playerTurnOffTrigger -= CloseTheDoor;
            m_LinkButton.playerTurnOnTrigger -= OpenTheDoor;
        }
    }
    private void OnEnable()
    {
        if (m_LinkButton)
        {
            m_LinkButton.playerTurnOffTrigger += CloseTheDoor;
            m_LinkButton.playerTurnOnTrigger += OpenTheDoor;
        }
    }

    private void CloseTheDoor()
    {
        transform.position -= Vector3.up * m_openShift;
    }

    private void OpenTheDoor()
    {
        transform.position += Vector3.up * m_openShift;
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

}
