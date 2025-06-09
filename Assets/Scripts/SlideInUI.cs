using UnityEngine;

public class SlideInUI : MonoBehaviour
{
    public RectTransform targetPanel;   // 확장될 패널
    public float duration = 0.5f;       // 확장 시간
    private bool isSliding = false;     // 중복 슬라이드 방지

    void Start()
    {
        if (targetPanel != null)
        {
            // 처음엔 스케일 0으로 설정 (왼쪽 기준으로 보이지 않게)
            targetPanel.localScale = new Vector3(0f, 1f, 1f);
            targetPanel.gameObject.SetActive(false);  // 초기엔 비활성화
        }
    }

    // 버튼에서 호출
    public void StartSlide()
    {
        if (!isSliding && targetPanel != null)
        {
            targetPanel.gameObject.SetActive(true);  // 슬라이드 시작 전 보이게
            StartCoroutine(SlideIn());
        }
    }

    private System.Collections.IEnumerator SlideIn()
    {
        isSliding = true;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / duration);

            // 왼쪽 기준으로 오른쪽으로 커짐
            targetPanel.localScale = new Vector3(progress, 1f, 1f);

            yield return null;
        }

        // 마지막 보정
        targetPanel.localScale = new Vector3(1f, 1f, 1f);
        isSliding = false;
    }
}
