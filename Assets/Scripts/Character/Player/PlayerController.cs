using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public Animator animator;  // 引入动画器组件
    public Vector2 inputDirection;
    public Transform healthBar;

    [Header("基本参数")]
    public float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputControl = new PlayerInputControl();
    }


    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
        //移动动画判定
        animator.SetFloat("Running", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
        healthBar.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, inputDirection.y * speed * Time.deltaTime);

    }

    void Flip()
    {
        float moveDir = Input.GetAxis("Horizontal"); //获取水平输入，unity内设置好的按键
        rb.velocity = new Vector2(moveDir * speed * Time.deltaTime, rb.velocity.y);

        //判断是否有速度再决定翻转
        bool faceDir = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (faceDir)
        {
            //判断方向
            if (rb.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (rb.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
