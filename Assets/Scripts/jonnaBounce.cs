using UnityEngine;

public class jonnaBounce : MonoBehaviour
{
    public float bounceSpeed = 3f;       // 흔들리는 속도
    public float bounceHeight = 0.05f;   // 흔들리는 높이

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.localPosition = new Vector3(originalPosition.x, originalPosition.y + offsetY, originalPosition.z);
    }
}
