using UnityEngine;

public class MomBounce : MonoBehaviour
{
    public float bounceSpeed = 8f;
    public float bounceHeight = 0.05f;

    private Vector3 visualOffset; // 흔들림만 따로 표현
    private PlayerMovement playerMovement;
    private Transform visualTransform;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        // Mom 안에 이미지(SpriteRenderer)가 있는 자식 오브젝트를 분리해서 흔들기
        // 또는 자기 자신을 흔들려면, Move와 Bounce를 분리해야 함
        visualTransform = transform.GetChild(0);  // Mom 안에 Sprite가 자식으로 들어있다고 가정
    }

    void Update()
    {
        if (playerMovement != null && playerMovement.IsMoving())
        {
            float bounceY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
            visualOffset = new Vector3(0, bounceY, 0);
        }
        else
        {
            visualOffset = Vector3.zero;
        }

        if (visualTransform != null)
        {
            visualTransform.localPosition = visualOffset;
        }
    }
}
