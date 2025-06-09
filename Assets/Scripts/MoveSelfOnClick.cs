using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MoveSelfOnClick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IDragHandler
{
    public Vector2 moveOffset = new Vector2(0, 50);
    public float moveDuration = 0.3f;

    private bool wasDragging = false;
    private Vector2 pressPos;
    private bool hasClicked = false;  // ✅ 이미 클릭했는지 여부

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
        if (wasDragging || hasClicked) return;  // ✅ 이미 클릭했으면 무시

        RectTransform rect = GetComponent<RectTransform>();
        if (rect != null)
        {
            Vector2 targetPos = rect.anchoredPosition + moveOffset;
            rect.DOAnchorPos(targetPos, moveDuration).SetEase(Ease.OutCubic);
            hasClicked = true;  // ✅ 클릭 처리 완료 표시
        }
    }
}
