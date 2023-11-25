using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Button : TrapBase
{
    public enum ButtonState
    {
        Off,
        On
    }

    [Header("Button")]
    [SerializeField]
    ButtonState m_buttonState = ButtonState.Off;

    Animator m_animator;

    // Outline
    [SerializeField] MeshRenderer m_buttonMeshRenderer;

    private bool m_isAppQuiting = false;

    // Start is called before the first frame update
    void Start()
    {
        m_isDoingDamage = false;
        m_animator = GetComponent<Animator>();
        m_buttonMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                // Do something with each hit object
                GameObject hitObject = hit.collider.gameObject;

                // For example, you can print the name of the object
                Debug.Log("Clicked on: " + hitObject.name);

                // Or perform other actions on the object
                // hitObject.GetComponent<YourComponent>().YourMethod();
            }
        }
        if (m_isPlayerInTrap)
        {
            OutlineOn();
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
        Debug.Log("OutlineOn");
    }
    private void OutlineOff()
    {
        SetOutlineAlpha(0.0f);
        Debug.Log("OutlineOff");
    }

    private void SetOutlineAlpha(float alpha)
    {
        Material mat = new Material(m_buttonMeshRenderer.material);
        Color temp = m_buttonMeshRenderer.material.GetColor("_OutlineColor");
        temp.a = alpha;
        mat.SetColor("_OutlineColor", temp);
        m_buttonMeshRenderer.material = mat;
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }
}
