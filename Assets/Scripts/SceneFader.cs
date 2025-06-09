using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        // 페이드 패널 활성화 후 투명하게 만들고 끄기
        fadeCanvasGroup.gameObject.SetActive(true);
        fadeCanvasGroup.alpha = 1f;

        fadeCanvasGroup.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            fadeCanvasGroup.gameObject.SetActive(false); // 투명해진 뒤 비활성화
        });
    }

    public void FadeToScene(string sceneName)
    {
        // 페이드 패널 다시 켜고 어둡게 만들기
        fadeCanvasGroup.gameObject.SetActive(true);
        fadeCanvasGroup.blocksRaycasts = true;

        fadeCanvasGroup.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}
