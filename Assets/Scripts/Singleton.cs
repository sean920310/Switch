using UnityEngine;

public abstract class SingletonInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance {get; private set;}
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

public abstract class Singleton<T> : SingletonInstance<T> where T: MonoBehaviour
{
    protected override void Awake()
    {
        if(Instance != null) 
        {
            Destroy(gameObject);
            Debug.LogError("Found more than one " + typeof(T) + " in the scene. Destroying the newest one.");
        }
        base.Awake();
    }
}

public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}