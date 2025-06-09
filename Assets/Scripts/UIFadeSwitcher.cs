using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIFadeSwitcher : MonoBehaviour
{
    public CanvasGroup[] oldUIElements; // 사라질 UI들
    public CanvasGroup[] newUIElements; // 나타날 UI들
    public float fadeDuration = 1.0f;

    public void SwitchUI()
    {
        StartCoroutine(FadeOutThenFadeIn());
    }

    private IEnumerator FadeOutThenFadeIn()
    {
        // 🔹 FadeOut → 비활성화까지
        yield return StartCoroutine(FadeAll(oldUIElements, 1f, 0f, false, true));

        // 🔹 FadeIn → 활성화 + 인터랙션 허용
        foreach (CanvasGroup cg in newUIElements)
        {
            if (cg != null)
                cg.gameObject.SetActive(true); // fade 전에 미리 활성화
        }

        yield return StartCoroutine(FadeAll(newUIElements, 0f, 1f, true, false));
    }

    private IEnumerator FadeAll(CanvasGroup[] groups, float from, float to, bool makeInteractive, bool deactivateAfterFadeOut)
    {
        List<Coroutine> fadeCoroutines = new List<Coroutine>();

        foreach (CanvasGroup cg in groups)
        {
            if (cg != null)
            {
                cg.alpha = from;

                // FadeIn 대상만 인터랙션 비활성화(이후 재활성화 예정)
                cg.interactable = false;
                cg.blocksRaycasts = false;

                fadeCoroutines.Add(StartCoroutine(Fade(cg, from, to)));
            }
        }

        foreach (Coroutine co in fadeCoroutines)
        {
            yield return co;
        }

        foreach (CanvasGroup cg in groups)
        {
            if (cg != null)
            {
                cg.alpha = to;
                cg.interactable = makeInteractive;
                cg.blocksRaycasts = makeInteractive;

                // ✅ fadeOut일 경우 GameObject 비활성화
                if (!makeInteractive && deactivateAfterFadeOut)
                    cg.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float from, float to)
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
