using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;
    public static T Instance
    {
        get
        {
            return GetInstance;

        }
    }
    private static T GetInstance()
    { 
        if( instance == null )
        {
            instance = FindFirstObjectByType<T>();
            if(instance == null)
            {
                GameObject go = new(typeof(T).ToString(), typeof(T));
                instance = go.GetComponent<T>();

                DontDestroyOnLoad(go);
            }
            else if(instance.gameObject.scene.name != "DontDestroyOnLoad")
            {
                DontDestroyOnLoad(instance.gameObject);
            }
        }
        return instance;
    }

    public void Awake()
    {
        GetInstance();
        if(instance && instance != this)
        {
            Debug.LogWarning($"Destroying duplicate {typeof(T).Name}");
            Destroy(this);
        }
    }
}
