using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    
    [Serializable]
    public enum StageType{
        NORMALROOM, // 普通房間(主要打怪)
        TRAPROOM,   // 陷阱房(著重於用SWITCH的跑酷)
        BOSSROOM,   // Boss房
    }

    [SerializeField]
    private StageType m_stageType;

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

    [SerializeField]
    private PolygonCollider2D m_cameraConfiner;

    public GameObject borderLeft { get => m_borderLeft; }
    public GameObject borderRight { get => m_borderRight; }
    public StageExitTrigger lastStageEnterTrigger { get => m_lastStageEnterTrigger;}
    public StageExitTrigger nextStageEnterTrigger { get => m_nextStageEnterTrigger;}
    public GameObject spownPointLeft { get => m_spownPointLeft; }
    public GameObject spownPointRight { get => m_spownPointRight; }
    public PolygonCollider2D CameraConfiner { get => m_cameraConfiner; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
