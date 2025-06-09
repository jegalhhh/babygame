using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CustomClickHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IDragHandler
{
    public CanvasGroup[] oldUIElements;
    public CanvasGroup[] newUIElements;
    public float fadeDuration = 1.0f;

    private bool wasDragging = false;
    private bool hasClicked = false;  // ✅ 클릭 여부 플래그
    private Vector2 pressPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        wasDragging = false;
        pressPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Vector2.Distance(eventData.position, pressPos) > 10f)
            wasDragging = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (wasDragging || hasClicked) return;  // ✅ 드래그거나 이미 클릭한 경우 무시

        //Debug.Log("진짜 클릭됨!");
        hasClicked = true;  // ✅ 한 번만 실행
        SwitchUI();
    }

    public void SwitchUI()
    {
        StartCoroutine(FadeOutThenFadeIn());
    }

    private IEnumerator FadeOutThenFadeIn()
    {
        yield return StartCoroutine(FadeAll(oldUIElements, 1f, 0f, false));
        yield return StartCoroutine(FadeAll(newUIElements, 0f, 1f, true));
    }

    private IEnumerator FadeAll(CanvasGroup[] groups, float from, float to, bool makeInteractive)
    {
        List<Coroutine> fadeCoroutines = new List<Coroutine>();

        foreach (CanvasGroup cg in groups)
        {
            if (cg != null)
            {
                cg.alpha = from;
                cg.interactable = makeInteractive;
                cg.blocksRaycasts = makeInteractive;
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
