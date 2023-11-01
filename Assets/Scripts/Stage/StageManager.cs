using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [Header("Stage Pool")]
    [SerializeField]
    private SceneField[] m_stagePool;

    [Header("Stage Choose")]
    [SerializeField]
    private int m_stageCountToChoose = 2;

    [SerializeField]
    private List<SceneField> m_chosenStages;

    [Header("Stage Shift")]
    private float m_stageObjsShiftAmount = 75f;

    private void Start()
    {
    }

    [ContextMenu("Load Stages")]
    private void LoadStages()
    {
        if(m_chosenStages.Count == 0)
        {
            Debug.LogWarning("No stage to load!");
            return;
        }

        for (int i = 0; i < m_chosenStages.Count; i++)
        {
            bool isSceneLoaded = false;

            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == m_chosenStages[i].SceneName)
                {
                    isSceneLoaded = true;
                    break;
                }
            }

            if (!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(m_chosenStages[i], LoadSceneMode.Additive);
            }
        }
    }

    [ContextMenu("UnLoad Stages")]
    private void UnLoadStages()
    {
        if (m_chosenStages.Count == 0)
        {
            Debug.LogWarning("No stage to unload!");
            return;
        }

        for (int i = 0; i < m_chosenStages.Count; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == m_chosenStages[i].SceneName)
                {
                    SceneManager.UnloadSceneAsync(loadedScene);
                }
            }
        }
    }

    [ContextMenu("Choose Stage From Stage Pool")]
    private void ChooseStageFromStagePool()
    {
        if(m_stageCountToChoose > m_stagePool.Length)
        {
            Debug.LogWarning("Can't Choose Stage: Stage pool count not enough!");
            return;
        }

        // Ramdon Pick Stages In Stage Pool (Non-repetitive)
        HashSet<int> uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < m_stageCountToChoose)
        {
            int randomNumber = UnityEngine.Random.Range(0, m_stagePool.Length);
            uniqueNumbers.Add(randomNumber);
        }

        foreach (int number in uniqueNumbers)
        {
            m_chosenStages.Add(m_stagePool[number]);
        }
    }

    [ContextMenu("Stage Shift")]
    private void StageShift()
    {
        if (m_chosenStages.Count == 1)
        {
            Debug.LogWarning("Not enough stage to shift!");
            return;
        }


        for (int i = 0; i < m_chosenStages.Count; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == m_chosenStages[i].SceneName)
                {
                    List<GameObject> sceneObjects = new List<GameObject>();
                    loadedScene.GetRootGameObjects(sceneObjects);

                    sceneObjects.ForEach(obj =>
                    {
                        // x position shift right
                        Vector3 objTransform = obj.transform.position;
                        obj.transform.position = objTransform + new Vector3(m_stageObjsShiftAmount * i, 0f, 0f);
                    });
                }
            }
        }
    }
}
