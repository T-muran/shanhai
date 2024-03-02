using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float moveSpeed;
    private Transform target;
    private SpriteRenderer theSR;
    public float damage;

    //攻击间隔时间
    public float hitWaitTime = 1;
    private float hitCounter;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GetInstance().StateMachine.GetState<PlayState>(GameController.GameState.Play.ToString(), out PlayState playState)) {
            //如果玩家死亡，敌人不再移动
            if (PlayerHealthController.instance.currentHp > 0)
            {
                enemy.velocity = (target.position - transform.position).normalized * moveSpeed;
                //攻击间隔时间
                if (hitCounter > 0f)
                {
                    hitCounter -= Time.deltaTime;
                }
                if (target.position.x > transform.position.x)
                {
                    theSR.flipX = true;
                }
                else
                {
                    theSR.flipX = false;
                }
            }
            else
            {
                enemy.velocity = Vector2.zero;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(damage);
            //间隔时间刷新
            hitCounter = hitWaitTime;
        }
    }
}
