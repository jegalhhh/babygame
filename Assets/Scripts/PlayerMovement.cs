using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 키보드 입력 처리
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 이동 방향에 따라 캐릭터 방향 반전
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  // 오른쪽 보기
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 보기
        }
    }

    void FixedUpdate()
    {
        // 이동 처리
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public bool IsMoving()
    {
        return movement.sqrMagnitude > 0.01f;
    }
}
