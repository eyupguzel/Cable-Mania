using UnityEngine;

public abstract class Singleton<T> :MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance => instance;

    protected virtual void Init() { }
    protected void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this);
            Init();
        }
        else
            Destroy(gameObject);
    }
    protected void OnDestroy()
    {
        if(instance == this)
            Destroy(gameObject);
    }
}
