using UnityEngine;

public class ButtonBounce : MonoBehaviour
{
    public float amplitude = 10f;  // 위아래로 흔들리는 범위
    public float frequency = 2f;   // 흔들리는 속도

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0, newY, 0);
    }
}
