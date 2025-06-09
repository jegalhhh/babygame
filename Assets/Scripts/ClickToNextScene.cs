using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToNextScene : MonoBehaviour
{
    public string nextSceneName;  // 넘어갈 씬 이름 (혹은 build index를 사용해도 됨)

    void Update()
    {
        // 마우스 왼쪽 클릭 또는 터치 입력 감지
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextSceneName); // 이름으로 불러오기
            // 또는 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // 다음 순서 씬으로
        }
    }
}
