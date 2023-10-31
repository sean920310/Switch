using UnityEngine;

public abstract class PersistentSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            try
            {
                if (!instance) instance = Instantiate(Resources.LoadAll<T>("SingletonManager")[0]).GetComponent<T>();
            }
            catch (System.Exception)
            {
                Debug.LogError("(" + typeof(T) + ") Singleton not found.");
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}