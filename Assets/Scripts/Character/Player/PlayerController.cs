using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public Animator animator;  // 引入动画器组件
    public Vector2 inputDirection;
   // public Transform healthBar;

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
        if (GameController.GetInstance().StateMachine.GetState<PlayState>(GameState.Play.ToString(), out PlayState playState))
        {
            inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
           // healthBar.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
        }
    }

    private void FixedUpdate()
    {
        if (GameController.GetInstance().StateMachine.GetState<PlayState>(GameState.Play.ToString(), out PlayState playState))
        {
            Move();
            Flip();
        }
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, inputDirection.y * speed * Time.deltaTime);
        //移动动画判定
        animator.SetFloat("Running", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }

    void Flip()
    {
        float moveDir = Input.GetAxis("Horizontal"); //获取水平输入，unity内设置好的按键
        rb.velocity = new Vector2(moveDir * speed * Time.deltaTime, rb.velocity.y);

        //判断是否有速度再决定翻转
        bool faceDir = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (faceDir)
        {
            //方向不同传入不同animator的参数
            animator.SetFloat("Left", rb.velocity.x < 0f ? 1f : -1f);
        }
    }
}
