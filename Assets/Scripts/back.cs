using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    void Update()
    {
        // 터치하거나 마우스를 클릭했을 때
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            SceneManager.LoadScene("TutorialScene");  // 이동할 씬 이름 입력
        }
    }
}
