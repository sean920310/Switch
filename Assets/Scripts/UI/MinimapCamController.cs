using StageSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MinimapCamController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float m_minimapSize;
    [SerializeField] private GameObject m_guideSymbolPrefab;
    [SerializeField] private bool m_enableGuideSymbol;

    private GameObject m_guideSymbol = null;
    private Vector3 m_guideSymbolTrans;
    private bool m_isAppQuiting = false;

    private void OnEnable()
    {
        if (m_enableGuideSymbol)
        {
            StageManager.Instance.onStageLoadedDone += OnSceneLoad;
            if (m_guideSymbol == null)
                m_guideSymbol = Instantiate(m_guideSymbolPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (m_enableGuideSymbol)
        {
            m_guideSymbol.transform.position = new Vector3(
                Mathf.Clamp(m_guideSymbolTrans.x, transform.position.x - m_minimapSize, transform.position.x + m_minimapSize),
                Mathf.Clamp(m_guideSymbolTrans.y, transform.position.y - m_minimapSize, transform.position.y + m_minimapSize),
                0
            );
        }
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

    private void OnDisable()
    {
        if (!m_isAppQuiting && m_enableGuideSymbol)
            StageManager.Instance.onStageLoadedDone -= OnSceneLoad;
    }

    private void OnSceneLoad()
    {
        m_guideSymbolTrans = StageManager.Instance.ChosenStagesInformations[StageManager.Instance.playerCurrentStage].stageController.nextStageEnterTrigger.gameObject.transform.position;
    }
}
