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
        if (step == 0)
        {
            balloons[step].SetActive(true);
            step++;
        }
        
        else if (step < balloons.Length)
        {
            balloons[step].SetActive(true);    // 현재 말풍선 꺼주고
            balloons[step - 1].SetActive(false);     // 다음 말풍선 바로 보여줌
            step++;
        }
        else if (step == balloons.Length)
        {
            // 마지막 말풍선 끄기
            balloons[step-1].SetActive(false);
           
        }
    }
}
