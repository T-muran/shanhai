using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float moveSpeed;
    private Transform target;
    public float damage;

    //¹¥»÷ÉËº¦¼ä¾à
    public float hitWaitTime = 1;
    private float hitCounter;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.velocity = (target.position - transform.position).normalized * moveSpeed;
        //¹¥»÷¼ä¸ôÊ±¼ä
        if(hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(damage);
            //Ë¢ÐÂ¹¥»÷¼ä¸ô
            hitCounter = hitWaitTime;
        }
    }
}
