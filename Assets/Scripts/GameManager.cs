using StageSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    [SerializeField]
    private PlayerEntity m_playerEntity;

    private int m_playerCurrentStage = 0;

    [SerializeField]
    private GameMasking m_gameMasking; // Fade In Fade Out Effect

    [SerializeField]
    private Cinemachine.CinemachineConfiner2D m_confiner2D;
    [SerializeField]
    private Cinemachine.CinemachineConfiner2D m_confiner3D;

    private void Start()
    {
        StageManager.Instance.onStageLoadedDone += OnStageLoadedDone;
        StageManager.Instance.onStageUnloaded += OnStageUnloaded;
        StageManager.Instance.onStageUnloadedDone += OnStageUnloadedDone;

        m_gameMasking.FadeIn();
        m_gameMasking.OnFadeInComplete += OnFadeInComplete;
    }

    private void OnStageLoadedDone()
    {
        // set player position
        Vector3 pos = StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.spownPointLeft.transform.position;
        m_playerEntity.transform.position = pos;

        BindStageExitTrigger();

        //if (StageManager.Instance.setStageActivationDynamicly)
        //{
        //    StageManager.Instance.SetStageActivation(m_playerCurrentStage, true);
        //}
    }

    private void OnStageUnloaded()
    {
        m_gameMasking.FadeIn();
        m_gameMasking.OnFadeInComplete += OnFadeInComplete;

        // set player inactive
        m_playerEntity.gameObject.SetActive(false);

        UnbindStageExitTrigger();
    }

    private void OnStageUnloadedDone()
    {
        m_playerCurrentStage = 0;
    }

    // unbind actions from current stage exit triggers
    private void UnbindStageExitTrigger()
    {
        if (StageManager.Instance.ChosenStagesInformations.Count <= m_playerCurrentStage) return;

        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.onStageExitTrigger -= OnPlayerEnterLastStageExitTrigger;
        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.onStageExitTrigger -= OnPlayerEnterNextStageExitTrigger;

        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.gameObject.SetActive(false);
        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.gameObject.SetActive(false);

        m_confiner2D.m_BoundingShape2D = null;
        m_confiner3D.m_BoundingShape2D = null;
    }

    // bind actions to current stage exit triggers
    private void BindStageExitTrigger()
    {
        if (StageManager.Instance.ChosenStagesInformations.Count <= m_playerCurrentStage) return;

        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.gameObject.SetActive(true);
        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.gameObject.SetActive(true);

        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.onStageExitTrigger += OnPlayerEnterLastStageExitTrigger;
        StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.onStageExitTrigger += OnPlayerEnterNextStageExitTrigger;

        m_confiner2D.m_BoundingShape2D = StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.CameraConfiner;
        //m_confiner3D.m_BoundingShape2D = StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.CameraConfiner;
    }

    // Action when player enter last stage exit trigger
    public void OnPlayerEnterLastStageExitTrigger(Collider2D collider2D)
    {
        if(collider2D.GetComponent<PlayerEntity>() == null)
        {
            // warning about player is not in trigger
            Debug.LogWarning("Player is not in trigger");
            return;
        }

        if(m_playerCurrentStage == StageManager.Instance.FirstStageIdx())
        {
            // warning about player is already in first stage
            Debug.LogWarning("Player is already in first stage");
            return;
        }
        m_gameMasking.FadeIn();
        // set player inactive
        m_playerEntity.gameObject.SetActive(false);

        UnbindStageExitTrigger();


        // Update current stage information
        m_playerCurrentStage--;
        StageManager.instance.LoadStageByStageIdx(m_playerCurrentStage);
        // Bind actions
        BindStageExitTrigger();
        m_gameMasking.OnFadeInComplete += OnFadeInComplete;

    }

    // Action when player enter next stage exit trigger
    public void OnPlayerEnterNextStageExitTrigger(Collider2D collider2D)
    {
        if (collider2D.GetComponent<PlayerEntity>() == null)
        {
            // warning about player is not in trigger
            Debug.LogWarning("Player is not in trigger");
            return;
        }
        if (m_playerCurrentStage == StageManager.Instance.LastStageIdx())
        {
            // warning about player is already in last stage
            Debug.LogWarning("Player is already in last stage");
            return;
        }

        m_gameMasking.FadeIn();

        // set player inactive
        m_playerEntity.gameObject.SetActive(false);

        UnbindStageExitTrigger();
        // Update current stage information
        m_playerCurrentStage++;
        StageManager.instance.LoadStageByStageIdx(m_playerCurrentStage);

        // Bind actions
        m_gameMasking.OnFadeInComplete += OnFadeInComplete;

    }


    public void OnFadeInComplete()
    {
        m_gameMasking.OnFadeInComplete -= OnFadeInComplete;

        m_gameMasking.FadeOut();
        m_gameMasking.OnFadeOutComplete += OnFadeOutComplete;


        // set player position to next stage spawn point
        Vector3 pos = StageManager.Instance.ChosenStagesInformations[m_playerCurrentStage].stageController.spownPointLeft.transform.position;
        m_playerEntity.transform.position = pos;
        BindStageExitTrigger();
    }

    public void OnFadeOutComplete()
    {
        m_gameMasking.OnFadeOutComplete -= OnFadeOutComplete;
        // set player active
        m_playerEntity.gameObject.SetActive(true);
    }
}
