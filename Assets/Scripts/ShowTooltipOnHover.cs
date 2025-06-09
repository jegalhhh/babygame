using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipObject;      // 보여줄 Text UI (GameObject)
    public bool isTooltipEnabled = true;  // Inspector에서 켜기/끄기

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isTooltipEnabled || tooltipObject == null) return;
        tooltipObject.SetActive(true);   // 즉각 표시
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isTooltipEnabled || tooltipObject == null) return;
        tooltipObject.SetActive(false);  // 즉각 숨김
    }
}
