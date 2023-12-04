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

    private GameObject m_guideSymbol;
    private Vector3 m_guideSymbolTrans;
    private bool m_isAppQuiting = false;

    private void OnEnable()
    {
        StageManager.Instance.onStageLoadedDone += OnSceneLoad;
        m_guideSymbol = Instantiate(m_guideSymbolPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        m_guideSymbol.transform.position = new Vector3(
            Mathf.Clamp(m_guideSymbolTrans.x, transform.position.x - m_minimapSize, transform.position.x + m_minimapSize),
            Mathf.Clamp(m_guideSymbolTrans.y, transform.position.y - m_minimapSize, transform.position.y + m_minimapSize),
            0
        );
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

    private void OnDisable()
    {
        if (!m_isAppQuiting)
            StageManager.Instance.onStageLoadedDone -= OnSceneLoad;
    }

    private void OnSceneLoad()
    {
        m_guideSymbolTrans = StageManager.Instance.ChosenStagesInformations[GameManager.Instance.PlayerCurrentStage].stageController.nextStageEnterTrigger.gameObject.transform.position;
    }
}
