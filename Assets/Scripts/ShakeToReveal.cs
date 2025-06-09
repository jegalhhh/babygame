using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ShakeToReveal : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CanvasGroup[] fadeInTargets;   // 나타날 UI들
    public CanvasGroup[] fadeOutTargets;  // 사라질 UI들
    public float shakeThreshold = 100f;
    public float fadeDuration = 1f;

    private Vector2 lastDragPos;
    private float shakeAmount = 0f;

    private RectTransform rectTransform;
    private Canvas parentCanvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPos = eventData.position;
        shakeAmount = 0f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
        {
            rectTransform.anchoredPosition = localPoint;
        }

        float deltaY = Mathf.Abs(eventData.position.y - lastDragPos.y);
        shakeAmount += deltaY;
        lastDragPos = eventData.position;

        if (shakeAmount >= shakeThreshold)
        {
            shakeAmount = 0f;

            // ✅ FadeIn 대상들: UI 보이게 + 활성화
            foreach (CanvasGroup cg in fadeInTargets)
            {
                if (cg != null)
                {
                    cg.gameObject.SetActive(true);          // 비활성화된 오브젝트 활성화
                    cg.interactable = true;
                    cg.blocksRaycasts = true;
                    cg.DOFade(1f, fadeDuration).SetEase(Ease.OutCubic);
                }
            }

            // ❌ FadeOut 대상들: 서서히 사라지고 비활성화
            foreach (CanvasGroup cg in fadeOutTargets)
            {
                if (cg != null)
                {
                    cg.interactable = false;
                    cg.blocksRaycasts = false;
                    cg.DOFade(0f, fadeDuration)
                      .SetEase(Ease.OutCubic)
                      .OnComplete(() => cg.gameObject.SetActive(false));
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        shakeAmount = 0f;
    }
}
