using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{

    [SerializeField]
    private GameObject m_borderLeft; 
    [SerializeField]
    private GameObject m_borderRight;
    [SerializeField]
    private StageExitTrigger m_lastStageEnterTrigger;
    [SerializeField]
    private StageExitTrigger m_nextStageEnterTrigger;

    [SerializeField]
    private GameObject m_spownPointLeft;
    [SerializeField]
    private GameObject m_spownPointRight;

    public GameObject borderLeft { get => m_borderLeft; }
    public GameObject borderRight { get => m_borderRight; }
    public StageExitTrigger lastStageEnterTrigger { get => m_lastStageEnterTrigger;}
    public StageExitTrigger nextStageEnterTrigger { get => m_nextStageEnterTrigger;}
    public GameObject spownPointLeft { get => m_spownPointLeft; }
    public GameObject spownPointRight { get => m_spownPointRight; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
