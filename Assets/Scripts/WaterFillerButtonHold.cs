using UnityEngine;
using UnityEngine.EventSystems;

public class WaterFillerButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform waterFill;
    public float fillSpeed = 100f;
    public float maxHeight = 500f;

    private bool isFilling = false;
    private float currentHeight = 0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        isFilling = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isFilling = false;
    }

    void Update()
    {
        if (isFilling)
        {
            currentHeight = Mathf.Min(currentHeight + fillSpeed * Time.deltaTime, maxHeight);
            waterFill.sizeDelta = new Vector2(waterFill.sizeDelta.x, currentHeight);
        }
    }
}
