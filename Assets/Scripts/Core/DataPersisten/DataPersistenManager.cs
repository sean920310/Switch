using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataPersistenManager : PersistentSingleton<DataPersistenManager>
{
    private List<IDataPersistence> dataPersistenceObjects;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    private void OnSceneUnloaded(Scene scene)
    {

    }
    
}