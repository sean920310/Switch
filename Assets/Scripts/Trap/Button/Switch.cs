using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Switch
    : TrapBase
{
    public enum SwitchState
    {
        Off,
        On
    }

    [Header("Button")]
    [SerializeField]
    SwitchState m_buttonState = SwitchState.Off;

    // Outline
    MeshRenderer m_buttonMeshRenderer;
    [SerializeField] private float m_fadeSpeed = 1.0f;

    [SerializeField] private bool m_isCellingButton = false;

    private float m_fadeAlpha = 0;

    private bool m_isAppQuiting = false;

    [SerializeField] Material m_switchOnMaterial;
    [SerializeField] Material m_switchOffMaterial;

    // Event
    public delegate void PlayerClickEvent();
    public event PlayerClickEvent playerTurnOnTrigger;
    public event PlayerClickEvent playerTurnOffTrigger;


    

    // Start is called before the first frame update
    void Start()
    {
        m_isDoingDamage = false;
        m_buttonMeshRenderer = GetComponent<MeshRenderer>();

        m_buttonMeshRenderer.material = m_switchOffMaterial;
        m_buttonState = SwitchState.Off;
    }

    // Update is called once per frame
    private void Update()
    {

        if(m_isPlayerInTrap && (!m_isCellingButton || m_isCellingButton && CameraManager.Instance.DimensionState == CameraManager.Dimension.ThreeD))
        {
            m_fadeAlpha = Mathf.Lerp(0, 0.3f, Mathf.PingPong(Time.time * m_fadeSpeed, 1.0f));
            SetOutlineAlpha(m_fadeAlpha);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D[] hits;
                if (CameraManager.Instance.DimensionState == CameraManager.Dimension.TwoD)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Camera.main.nearClipPlane;
                    Vector2 wp = Camera.main.ScreenToWorldPoint(mousePos);
                    hits = Physics2D.RaycastAll(wp, Vector2.zero, 1000f);
                }
                else
                {

                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    hits = Physics2D.RaycastAll(r.origin, r.direction);
                }

                foreach (RaycastHit2D hit in hits)
                {
                    GameObject hitObject = hit.collider.gameObject;

                    if (hit.collider.gameObject.GetComponent<Switch>())
                    {
                        Debug.Log("Switch");
                        if (m_buttonState == SwitchState.Off)
                        {
                            OutlineOff();
                            m_buttonMeshRenderer.material = m_switchOnMaterial;
                            m_buttonState = SwitchState.On;
                            playerTurnOnTrigger?.Invoke();
                        }
                        else
                        {
                            OutlineOff();
                            m_buttonMeshRenderer.material = m_switchOffMaterial;
                            m_buttonState = SwitchState.Off;
                            playerTurnOffTrigger?.Invoke();
                        }
                        break;
                    }
                }

            }
        }
        else
        {
            OutlineOff();
        }
    }

    private void OnDisable()
    {
        SetOutlineAlpha(0);
        if (!m_isAppQuiting)
        {
            playerEnterTrigger -= OutlineOn;
            playerExitTrigger -= OutlineOff;
        }
    }
    private void OnEnable()
    {
        playerEnterTrigger += OutlineOn;
        playerExitTrigger += OutlineOff;
    }

    private void OutlineOn()
    {
        SetOutlineAlpha(0.3f);
    }
    private void OutlineOff()
    {
        SetOutlineAlpha(0.0f);
    }

    private void SetOutlineAlpha(float alpha)
    {
        Color temp = m_buttonMeshRenderer.material.GetColor("_OutlineColor");
        temp.a = alpha;
        m_buttonMeshRenderer.material.SetColor("_OutlineColor", temp);

    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }
}
