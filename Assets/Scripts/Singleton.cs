using UnityEngine;

/// <summary>씬 전환 후에도 하나의 인스턴스만 유지하는 제네릭 MonoBehaviour 기반 클래스입니다.</summary>
/// <typeparam name="T">싱글턴으로 사용할 MonoBehaviour 형식입니다.</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance; // 현재 사용 중인 유일한 인스턴스를 보관합니다.

    /// <summary>기존 인스턴스를 찾거나, 없으면 새 게임 오브젝트에 생성하여 반환합니다.</summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name); // 자동 생성할 싱글턴 게임 오브젝트입니다.
                    _instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    /// <summary>첫 인스턴스를 등록하고 중복 생성된 게임 오브젝트를 제거합니다.</summary>
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
