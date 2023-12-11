using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace StageSystem
{
    [Serializable]
    public class StageInformation
    {
        // Hierarchical structure of stageController:
        // StageController
        //  |- SpawnPoint
        //      |- Left
        //      |- Right
        //  |- Border
        //      |- Left
        //      |- Right
        //  |- StageEnterTrigger
        //      |- LastStageEnterTrigger
        //      |- NextStageEnterTrigger

        // Current Stage Information
        public StageController stageController;

        // Stage Relationship
        [Header("Stage Relationship")]
        public StageController lastStage;
        public StageController nextStage;

        public bool stageShifted = false;

        public StageInformation(StageController stageController, StageController lastStage, StageController nextStage)
        {
            loadStageInformation(stageController, lastStage, nextStage);
            stageShifted = false;
        }

        // load stage information with stageController
        private void loadStageInformation(StageController stageController, StageController lastStage, StageController nextStage)
        {
            // Assign each part of stageController
            this.stageController = stageController;
            this.lastStage = lastStage;
            this.nextStage = nextStage;
        }

        public void SetNextStage(StageController nextStage)
        {
            this.nextStage = nextStage;
        }
    }

    public enum StageState
    {
        StageNotChoose,
        StageChose,
        StageLoading,
        StageLoaded,
        StageUnLoading,
    }

    public class StageManager : PersistentSingleton<StageManager>
    {
        [Header("Stage Pool")]
        [SerializeField]
        private SceneField[] m_stagePool;

        [Header("Stage Choose")]
        [SerializeField]
        private bool m_setStageActivationDynamicly = false; // Currently not working
        public bool setStageActivationDynamicly { get => m_setStageActivationDynamicly; } // Currently not working

        [SerializeField]
        private bool m_loadStageAutomatically = false;

        [SerializeField]
        private bool m_stageRandomize = false;

        [SerializeField]
        private int m_stageCountToChoose = 2;

        [SerializeField]
        private List<SceneField> m_chosenStages = new List<SceneField>();

        [SerializeField]
        private List<StageInformation> m_chosenStagesInformations = new List<StageInformation>();
        public List<StageInformation> ChosenStagesInformations { get => m_chosenStagesInformations;}

        [ReadOnly]
        [SerializeField]
        private List<AsyncOperation> m_stagesToLoad = new List<AsyncOperation>();
        [ReadOnly]
        [SerializeField]
        private int m_loadedStageCount = 0;
        [ReadOnly]
        [SerializeField]
        private List<AsyncOperation> m_stagesToUnload = new List<AsyncOperation>();
        [ReadOnly]
        [SerializeField]
        private int m_unloadedStageCount = 0;

        //[Header("Stage Shift")]
        //[SerializeField]
        //private float m_stageObjsShiftAmount = 75f;

        [ReadOnly]
        [SerializeField]
        private StageState m_stageState = StageState.StageNotChoose;


        // delegate and action for each stage state done
        public delegate void StageStateDone();
        public event StageStateDone onStageLoadedDone;

        // delegate and action for unloading stage done
        public delegate void StageUnloadingDone();
        public event StageUnloadingDone onStageUnloadedDone;

        public delegate void StageUnloading();
        public event StageUnloading onStageUnloaded;

        public int playerCurrentStage = 0;

        private void Start()
        {
        }

        private void Update()
        {
            switch (m_stageState)
            {
                case StageState.StageNotChoose:
                    if (m_loadStageAutomatically)
                    {
                        if(m_stageRandomize)
                            RandomChooseStageFromStagePool();
                        else
                            ChooseStageFromStagePool();
                    }
                    break;
                case StageState.StageChose:
                    LoadStagesFromChosenStages(playerCurrentStage);
                    break;
                case StageState.StageLoading:
                    // Check if all stages are loaded
                    if (/*m_stagesToLoad.Count == m_chosenStages.Count && */m_loadedStageCount == m_stagesToLoad.Count)
                    {
                        m_stageState = StageState.StageLoaded;
                        m_loadedStageCount = 0;


                        // load stage information when stage is all loaded
                        LoadStagesInformations(playerCurrentStage);
                        StageShiftWithBorderPosition();

                        onStageLoadedDone?.Invoke();
                    }
                    break;
                case StageState.StageLoaded:
                    break;
                case StageState.StageUnLoading:
                    // Check if all stages are loaded
                    if (m_stagesToUnload.Count == m_chosenStages.Count && m_unloadedStageCount == m_stagesToUnload.Count)
                    {
                        m_stageState = StageState.StageNotChoose;

                        StageInfoReset();
                        onStageUnloadedDone?.Invoke();
                    }
                    break;
                default:
                    break;
            }

        }
        private void LoadStagesFromChosenStages(int playerCurrentStage)
        {
            if (m_chosenStages.Count == 0)
            {
                Debug.LogWarning("No stage to load!");
                return;
            }

            // Switch Stage State
            m_stageState = StageState.StageLoading;

            m_stagesToLoad.Clear();
            m_loadedStageCount = 0;

            // Load Scene
            for (int i = 0; i < playerCurrentStage + 1; i++)
            // for (int i = 0; i < m_chosenStages.Count; i++)
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
                    m_stagesToLoad.Add(SceneManager.LoadSceneAsync(m_chosenStages[i], LoadSceneMode.Additive));
                    m_stagesToLoad[m_stagesToLoad.Count - 1].completed += OnStageLoaded;
                }
            }
        }
        private void LoadStagesInformations(int playerCurrentStage)
        {

            // Load Scene
            for (int i = 0; i < playerCurrentStage + 1; i++)
            // for (int i = 0; i < m_chosenStages.Count; i++)
            {
                if (m_chosenStagesInformations.Count - 1 >= i) continue;

                for (int j = 0; j < SceneManager.sceneCount; j++)
                {
                    Scene loadedScene = SceneManager.GetSceneAt(j);
                    if (loadedScene.name == m_chosenStages[i].SceneName)
                    {
                        // Get StageController
                        GameObject[] sceneObjects = loadedScene.GetRootGameObjects();
                        StageController stageController = null;
                        foreach (GameObject obj in sceneObjects)
                        {
                            if (obj.name == "StageController")
                            {
                                stageController = obj.GetComponent<StageController>();
                                break;
                            }
                        }
                        if (stageController != null)
                        {
                            StageController lastStage = null;
                            if (i > 0)
                            {
                                // Get Last Stage
                                lastStage = m_chosenStagesInformations[i - 1].stageController;

                                // Set Next Stage of Last Stage
                                m_chosenStagesInformations[i - 1].SetNextStage(stageController);
                            }

                            // Add Stage Information
                            m_chosenStagesInformations.Add(new StageInformation(stageController, lastStage, null));
                        }
                        else
                        {
                            Debug.LogWarning("Can't find StageController in scene: " + loadedScene.name);

                        }
                        break;
                    }
                }
            }
        }
        private void RandomChooseStageFromStagePool()
        {
            if (m_stageCountToChoose > m_stagePool.Length)
            {
                Debug.LogWarning("Can't Choose Stage: Stage pool count not enough!");
                return;
            }

            // Clear Chosen Stages
            m_chosenStages.Clear();

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

            // Switch Stage State
            m_stageState = StageState.StageChose;
        }

        private void ChooseStageFromStagePool()
        {
            if (m_stagePool.Length == 0)
            {
                Debug.LogWarning("Can't Choose Stage: Stage pool count not enough!");
                return;
            }

            // Clear Chosen Stages
            m_chosenStages.Clear();

            for (int i = 0; i < m_stagePool.Length; i++)
            {
                m_chosenStages.Add(m_stagePool[i]);
            }

            // Switch Stage State
            m_stageState = StageState.StageChose;
        }

        //private void StageShift()
        //{
        //    if (m_chosenStages.Count == 1)
        //    {
        //        Debug.LogWarning("Not enough stage to shift!");
        //        return;
        //    }


        //    for (int i = 0; i < m_chosenStages.Count; i++)
        //    {
        //        for (int j = 0; j < SceneManager.sceneCount; j++)
        //        {
        //            Scene loadedScene = SceneManager.GetSceneAt(j);
        //            if (loadedScene.name == m_chosenStages[i].SceneName)
        //            {
        //                List<GameObject> sceneObjects = new List<GameObject>();
        //                loadedScene.GetRootGameObjects(sceneObjects);

        //                sceneObjects.ForEach(obj =>
        //                {
        //                    // x position shift right
        //                    Vector3 objTransform = obj.transform.position;
        //                    obj.transform.position = objTransform + new Vector3(m_stageObjsShiftAmount * i, 0f, 0f);
        //                });
        //            }
        //        }
        //    }
        //}
        private void StageShiftWithBorderPosition()
        {
            if (m_chosenStages.Count == 1)
            {
                Debug.LogWarning("Not enough stage to shift!");
                return;
            }

            float xShiftAmount = 0f;
            for (int i = 0; i < m_chosenStages.Count; i++)
            {

                for (int j = 0; j < SceneManager.sceneCount; j++)
                {
                    Scene loadedScene = SceneManager.GetSceneAt(j);
                    if (loadedScene.name == m_chosenStages[i].SceneName)
                    {
                        List<GameObject> sceneObjects = new List<GameObject>();
                        loadedScene.GetRootGameObjects(sceneObjects);

                        // Shift each stage position to prevent map overlap with border position
                        if(i > 0)
                        {
                            xShiftAmount += (m_chosenStagesInformations[i - 1].stageController.borderRight.transform.position.x - m_chosenStagesInformations[i - 1].stageController.borderLeft.transform.position.x) / 2 + 
                                                    (m_chosenStagesInformations[i].stageController.borderRight.transform.position.x - m_chosenStagesInformations[i].stageController.borderLeft.transform.position.x) / 2;
                        }else if(i == 0)
                        {
                            xShiftAmount = (m_chosenStagesInformations[i].stageController.borderRight.transform.position.x - m_chosenStagesInformations[i].stageController.borderLeft.transform.position.x) / 2;
                        }

                        float centerNormallize = (m_chosenStagesInformations[i].stageController.borderRight.transform.position.x + m_chosenStagesInformations[i].stageController.borderLeft.transform.position.x) / 2;

                        // Debug.Log(i + ": centerNormallize: " + centerNormallize);

                        if (m_chosenStagesInformations.Count > i && m_chosenStagesInformations[i].stageShifted)
                        {
                            continue;
                        }
                        else
                        {
                            sceneObjects.ForEach(obj =>
                            {
                                obj.transform.position = new Vector3(xShiftAmount - centerNormallize, obj.transform.position.y, obj.transform.position.z);
                            });
                        }

                        m_chosenStagesInformations[i].stageShifted = true;
                    }
                }
            }
        }
        private void StageInfoReset()
        {
            m_chosenStages.Clear();
            m_chosenStagesInformations.Clear();
            m_stagesToUnload.Clear();
            m_stagesToLoad.Clear();
            m_loadedStageCount = 0;
            m_unloadedStageCount = 0;
        }

        public int LastStageIdx()
        {
            return m_chosenStages.Count - 1;
        }

        public int FirstStageIdx()
        {
            return 0;
        }

        public void SetAllStageUnactive()
        {
            m_stagesToLoad.ForEach(stage => stage.allowSceneActivation = false);
        }
        public void SetStageActivation(int stageIdx, bool activation)
        {
            m_stagesToLoad[stageIdx].allowSceneActivation = activation;
        }

        // Callbacks for loading and unloading stages
        private void OnStageLoaded(AsyncOperation asyncOperation)
        {
            Debug.Log("Stage loaded: " + m_loadedStageCount + " / " + m_chosenStages.Count);
            asyncOperation.completed -= OnStageLoaded;
            m_loadedStageCount++;
        }
        private void OnStageUnloaded(AsyncOperation asyncOperation)
        {
            Debug.Log("Stage unloaded: " + m_unloadedStageCount + " / " + m_chosenStages.Count);
            asyncOperation.completed -= OnStageUnloaded;
            m_unloadedStageCount++;
        }

        public void LoadStageByStageIdx(int playerCurrentStage)
        {
            this.playerCurrentStage = playerCurrentStage;
            m_stageState = StageState.StageChose;
        }

        [ContextMenu("UnLoad Stages")]
        public void UnLoadStages()
        {
            if (m_chosenStages.Count == 0 || m_stageState != StageState.StageLoaded)
            {
                Debug.LogWarning("No stage to unload!");
                return;
            }

            // Switch Stage State
            m_stageState = StageState.StageUnLoading;

            onStageUnloaded?.Invoke();

            m_stagesToUnload.Clear();
            m_unloadedStageCount = 0;

            for (int i = 0; i < m_chosenStages.Count; i++)
            {
                for (int j = 0; j < SceneManager.sceneCount; j++)
                {
                    Scene loadedScene = SceneManager.GetSceneAt(j);
                    if (loadedScene.name == m_chosenStages[i].SceneName)
                    {
                        m_stagesToUnload.Add(SceneManager.UnloadSceneAsync(loadedScene));
                        m_stagesToUnload[m_stagesToUnload.Count - 1].completed += OnStageUnloaded;
                    }
                }
            }
        }

        [ContextMenu("Load Stages To Scene")]
        public void LoadStagesToScene()
        {
            if (m_stageState != StageState.StageNotChoose)
            {
                Debug.LogWarning("Failed to load stages to scene: Current stages needs to unload first");
                return;
            }

            RandomChooseStageFromStagePool();
        }
    }

};
