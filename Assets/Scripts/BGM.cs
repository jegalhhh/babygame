using UnityEngine;

public class BGM : MonoBehaviour
{
    private static BGM instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환에도 유지됨
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
}
