using StageSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : PersistentSingleton<GameManager>
{
    private StageManager m_stageManager;
    [SerializeField]
    private PlayerEntity m_playerEntity;

    private int m_playerCurrentStage = 0;

    [SerializeField]
    private GameMasking m_gameMasking;

    private void Start()
    {
        m_stageManager = StageManager.Instance;
        m_stageManager.onStageLoadedDone += OnStageLoadedDone;

        m_gameMasking.FadeIn();
    }

    private void OnStageLoadedDone()
    {
        m_stageManager.onStageLoadedDone -= OnStageLoadedDone;

        // set player position
        Vector3 pos = m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.spownPointLeft.transform.position;
        m_playerEntity.transform.position = pos;

        BindStageExitTrigger();
        m_gameMasking.OnFadeInComplete += OnFadeInComplete;
    }

    // unbind actions from current stage exit triggers
    private void UnbindStageExitTrigger()
    {
        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.onStageExitTrigger -= OnPlayerEnterLastStageExitTrigger;
        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.onStageExitTrigger -= OnPlayerEnterNextStageExitTrigger;

        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.gameObject.SetActive(false);
        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.gameObject.SetActive(false);
    }

    // bind actions to current stage exit triggers
    private void BindStageExitTrigger()
    {
        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.gameObject.SetActive(true);
        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.gameObject.SetActive(true);

        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.lastStageEnterTrigger.onStageExitTrigger += OnPlayerEnterLastStageExitTrigger;
        m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.nextStageEnterTrigger.onStageExitTrigger += OnPlayerEnterNextStageExitTrigger;
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

        if(m_playerCurrentStage == 0)
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

        // set player position to last stage spawn point
        Vector3 pos = m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.spownPointRight.transform.position;
        m_playerEntity.transform.position = pos;

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
        if (m_playerCurrentStage == m_stageManager.ChosenStagesInformations.Count - 1)
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

        // set player position to next stage spawn point
        Vector3 pos = m_stageManager.ChosenStagesInformations[m_playerCurrentStage].stageController.spownPointLeft.transform.position;
        m_playerEntity.transform.position = pos;

        // Bind actions
        BindStageExitTrigger();
        m_gameMasking.OnFadeInComplete += OnFadeInComplete;

    }


    public void OnFadeInComplete()
    {
        m_gameMasking.OnFadeInComplete -= OnFadeInComplete;

        m_gameMasking.FadeOut();
        m_gameMasking.OnFadeOutComplete += OnFadeOutComplete;
    }

    public void OnFadeOutComplete()
    {
        m_gameMasking.OnFadeOutComplete -= OnFadeOutComplete;
        // set player active
        m_playerEntity.gameObject.SetActive(true);
    }
}
