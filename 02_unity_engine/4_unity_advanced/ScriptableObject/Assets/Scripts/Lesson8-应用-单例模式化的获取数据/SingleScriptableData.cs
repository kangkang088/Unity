using UnityEngine;

public class SingleScriptableData<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<T>(typeof(T).Name);
                if (instance == null)
                {
                    Debug.LogError($"Failed to load {typeof(T).Name} from Resources.");
                    instance = CreateInstance<T>();
                    // 或者json中读取（涉及持久化，不建议用Scriptable做数据持久化）
                }
            }
            return instance;
        }
    }
}
