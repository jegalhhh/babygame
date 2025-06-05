using UnityEngine;

public class TutorialShow : MonoBehaviour
{
    public GameObject[] balloons;  // 말풍선 배열
    private int step = 0;

    void Start()
    {
        // 모든 말풍선 숨기고, 첫 번째만 보여주기
        for (int i = 0; i < balloons.Length; i++)
        {
            balloons[i].SetActive(false);
        }

        if (balloons.Length > 0)
        {
            balloons[0].SetActive(true);  // 첫 번째 말풍선 자동 등장
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextBalloon();
        }
    }

    void ShowNextBalloon()
    {
        if (step < balloons.Length - 1)
        {
            balloons[step].SetActive(false);    // 현재 말풍선 꺼주고
            step++;                              // 다음 인덱스로 이동
            balloons[step].SetActive(true);     // 다음 말풍선 바로 보여줌
        }
        else if (step == balloons.Length - 1)
        {
            // 마지막 말풍선 끄기
            balloons[step].SetActive(false);
            step++;
        }
    }
}
