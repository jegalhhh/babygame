using UnityEngine;
using System.Collections;

public class MUA : MonoBehaviour
{
    public CanvasGroup[] uiElements;  // Fade In 시킬 UI 그룹
    public float fadeDuration = 1.0f; // Fade In 시간

    public void FadeInAll()
    {
        foreach (CanvasGroup cg in uiElements)
        {
            StartCoroutine(FadeIn(cg));
        }
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
